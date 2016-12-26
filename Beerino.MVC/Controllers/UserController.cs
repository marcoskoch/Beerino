using AutoMapper;
using Beerino.Application.Interface;
using Beerino.Domain.Entities;
using Beerino.MVC.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace Beerino.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userApp;

        public UserController(IUserAppService userApp)
        {
            _userApp = userApp;
        }

        [Authorize]
        public ActionResult Index()
        {
            var userViewModel = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(_userApp.GetAll());

            return View(userViewModel);
        }

        [Authorize]
        public ActionResult Especiais()
        {
            var userViewModel = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(_userApp.getSpecialUsers());

            return View(userViewModel);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var user = _userApp.GetById(id);
            var userViewModel = Mapper.Map<User, UserViewModel>(user);

            return View(userViewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var EmailAddress = claimsIdentity?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var newUser = new UserViewModel();

            newUser.Name = claimsIdentity.Name;
            newUser.Email = EmailAddress;
            newUser.Active = true;
            
            return View(newUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userDomain = Mapper.Map<UserViewModel, User>(user);
                _userApp.Add(userDomain);

                RedirectToAction("Index");
            }

            return View(user);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var user = _userApp.GetById(id);
            var userViewModel = Mapper.Map<User, UserViewModel>(user);

            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userDomain = Mapper.Map<UserViewModel, User>(user);
                _userApp.Update(userDomain);

                RedirectToAction("Index");
            }

            return View(user);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var user = _userApp.GetById(id);
            var userViewModel = Mapper.Map<User, UserViewModel>(user);

            return View(userViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = _userApp.GetById(id);
            _userApp.Remove(user);

            return RedirectToAction("Index");
        }
    }
}
