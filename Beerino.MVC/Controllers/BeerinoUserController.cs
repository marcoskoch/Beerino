using AutoMapper;
using Beerino.Application.Interface;
using Beerino.Domain.Entities;
using Beerino.MVC.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Beerino.MVC.Controllers
{
    public class BeerinoUserController : Controller
    {
        private readonly IBeerinoUserAppService _beerinoUserApp;
        private readonly IUserAppService _userApp;
        private readonly IBeerAppService _beerApp;

        public BeerinoUserController(IBeerinoUserAppService beerinoUserApp, IUserAppService userApp, IBeerAppService beerApp)
        {
            _beerinoUserApp = beerinoUserApp;
            _userApp = userApp;
            _beerApp = beerApp;
        }

        // GET: BeerinoUser
        public ActionResult Index()
        {
            var beerinoUserViewModel = Mapper.Map<IEnumerable<BeerinoUser>, IEnumerable<BeerinoUserViewModel>>(_beerinoUserApp.GetAll());

            return View(beerinoUserViewModel);
        }

        // GET: BeerinoUser/Details/5
        public ActionResult Details(int id)
        {
            var beerinoUser = _beerinoUserApp.GetById(id);
            var beerinoUserViewModel = Mapper.Map<BeerinoUser, BeerinoUserViewModel>(beerinoUser);

            return View();
        }

        // GET: BeerinoUser/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(_userApp.GetAll(), "UserID", "Name");
            ViewBag.BeerID = new SelectList(_beerApp.GetAll(), "BeerID", "Name");

            return View();
        }

        // POST: BeerinoUser/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeerinoUserViewModel beerino)
        {
            if (ModelState.IsValid)
            {
                var beerinoUserDomain = Mapper.Map<BeerinoUserViewModel, BeerinoUser>(beerino);
                _beerinoUserApp.Add(beerinoUserDomain);

                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(_userApp.GetAll(), "UserID", "Name", beerino.UserID);
            ViewBag.BeerID = new SelectList(_beerApp.GetAll(), "BeerID", "Name", beerino.BeerID);

            return View(beerino);
        }

        // GET: BeerinoUser/Edit/5
        public ActionResult Edit(int id)
        {
            var beerino = _beerinoUserApp.GetById(id);
            var beerinoViewModel = Mapper.Map<BeerinoUser, BeerinoUserViewModel>(beerino);

            ViewBag.UserID = new SelectList(_userApp.GetAll(), "UserID", "Name", beerino.UserID);
            ViewBag.BeerID = new SelectList(_beerApp.GetAll(), "BeerID", "Name", beerino.BeerID);

            return View(beerinoViewModel);
        }

        // POST: BeerinoUser/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeerinoUserViewModel beerino)
        {
            if (ModelState.IsValid)
            {
                var beerinoUserDomain = Mapper.Map<BeerinoUserViewModel, BeerinoUser>(beerino);
                _beerinoUserApp.Update(beerinoUserDomain);

                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(_userApp.GetAll(), "UserID", "Name", beerino.UserID);
            ViewBag.BeerID = new SelectList(_beerApp.GetAll(), "BeerID", "Name", beerino.BeerID);

            return View(beerino);
        }

        // GET: BeerinoUser/Delete/5
        public ActionResult Delete(int id)
        {
            var beerino = _beerinoUserApp.GetById(id);
            var beerinoViewModel = Mapper.Map<BeerinoUser, BeerinoUserViewModel>(beerino);

            return View(beerinoViewModel);
        }

        // POST: BeerinoUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var beerino = _beerinoUserApp.GetById(id);
            _beerinoUserApp.Remove(beerino);

            return RedirectToAction("Index");
        }
    }
}
