using AutoMapper;
using Beerino.Application.Interface;
using Beerino.Domain.Entities;
using Beerino.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace Beerino.MVC.Controllers
{
    public class BeerController : Controller
    {
        private readonly IBeerAppService _beerApp;
        private readonly IUserAppService _userApp;

        public BeerController(IBeerAppService beerApp, IUserAppService userApp)
        {
            _beerApp = beerApp;
            _userApp = userApp;
        }

        // GET: Beer
        [Authorize]
        public ActionResult Index()
        {
            var beerModelView = Mapper.Map<IEnumerable<Beer>, IEnumerable<BeerViewModel>>(_beerApp.GetAll());

            return View(beerModelView);
        }

        // GET: Beer/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var beer = _beerApp.GetById(id);
            var beerViewModel = Mapper.Map<Beer, BeerViewModel>(beer);

            return View(beerViewModel);
        }

        // GET: Beer/Create
        [Authorize]
        public ActionResult Create()
        {
            return View(new BeerViewModel());
        }

        // POST: Beer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(BeerViewModel beer)
        {
            if (ModelState.IsValid)
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                var EmailAddress = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                int userId = _userApp.GetIdByEmail(EmailAddress);

                beer.UserID = Convert.ToInt32(userId);

                var beerDomain = Mapper.Map<BeerViewModel, Beer>(beer);
                _beerApp.Add(beerDomain);

                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(_userApp.GetAll(), "UserID", "Name", beer.UserID);

            return View(beer);
        }

        // GET: Beer/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var beer = _beerApp.GetById(id);
            var beerViewModel = Mapper.Map<Beer, BeerViewModel>(beer);

            ViewBag.UserID = new SelectList(_userApp.GetAll(), "UserID", "Name", beer.UserID);

            return View(beerViewModel);
        }

        // POST: Beer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(BeerViewModel beer)
        {
            if (ModelState.IsValid)
            {
                var beerDomain = Mapper.Map<BeerViewModel, Beer>(beer);
                _beerApp.Add(beerDomain);

                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(_userApp.GetAll(), "UserID", "Name", beer.UserID);

            return View(beer);
        }

        // GET: Beer/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var beer = _beerApp.GetById(id);
            var beerViewModel = Mapper.Map<Beer, BeerViewModel>(beer);

            return View(beerViewModel);
        }

        // POST: Beer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var beer = _beerApp.GetById(id);
            _beerApp.Remove(beer);

            return RedirectToAction("Index");
        }
    }
}
