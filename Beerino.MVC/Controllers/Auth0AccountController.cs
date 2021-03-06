using Beerino.Application.Interface;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Beerino.MVC.Controllers
{
    public class Auth0AccountController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private readonly IUserAppService _userApp;

        public Auth0AccountController(IUserAppService userApp)
        {
            _userApp = userApp;
        }

        //
        // GET: /Auth0Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            var externalIdentity = await AuthenticationManager.GetExternalIdentityAsync(DefaultAuthenticationTypes.ExternalCookie);
            if (externalIdentity == null)
            {
                throw new Exception("Could not get the external identity. Please check your Auth0 configuration settings and ensure that " +
                                    "you configured UseCookieAuthentication and UseExternalSignInCookie in the OWIN Startup class. " +
                                    "Also make sure you are not calling setting the callbackOnLocationHash option on the JavaScript login widget.");
            }

            var userLogado = CreateIdentity(externalIdentity);
            var EmailAddress = userLogado.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            int userId = _userApp.GetIdByEmail(EmailAddress);

            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = false }, userLogado);

            userLogado.AddClaim(new Claim("user.id", userId.ToString()));

            if (userId == 0)
                return RedirectToAction("Create", "User");

            return RedirectToLocal(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff(string returnUrl)
        {
            var appTypes = AuthenticationManager.GetAuthenticationTypes().Select(at => at.AuthenticationType).ToArray();
            AuthenticationManager.SignOut(appTypes);

            var absoluteReturnUrl = string.IsNullOrEmpty(returnUrl) ?
                this.Url.Action("Index", "Home", new { }, this.Request.Url.Scheme) :
                this.Url.IsLocalUrl(returnUrl) ?
                    new Uri(this.Request.Url, returnUrl).AbsoluteUri : returnUrl;

            return Redirect(
                string.Format("https://{0}/v2/logout?returnTo={1}",
                    ConfigurationManager.AppSettings["auth0:Domain"],
                    absoluteReturnUrl));
        }

        private static ClaimsIdentity CreateIdentity(ClaimsIdentity externalIdentity)
        {
            var identity = new ClaimsIdentity(externalIdentity.Claims, DefaultAuthenticationTypes.ApplicationCookie);

            // This claim is required for the ASP.NET Anti-Forgery Token to function.
            // See http://msdn.microsoft.com/en-us/library/system.web.helpers.antiforgeryconfig.uniqueclaimtypeidentifier(v=vs.111).aspx
            identity.AddClaim(
                new Claim(
                    "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                    "ASP.NET Identity",
                    "http://www.w3.org/2001/XMLSchema#string"));

            return identity;
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}