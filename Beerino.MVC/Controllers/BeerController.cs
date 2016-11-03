﻿using AutoMapper;
using Beerino.Application.Interface;
using Beerino.Domain.Entities;
using Beerino.MVC.ViewModel;
using System.Collections.Generic;
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
        public ActionResult Index()
        {
            var beerModelView = Mapper.Map<IEnumerable<Beer>, IEnumerable<BeerViewModel>>(_beerApp.GetAll());

            return View(beerModelView);
        }

        // GET: Beer/Details/5
        public ActionResult Details(int id)
        {
            var beer = _beerApp.GetById(id);
            var beerViewModel = Mapper.Map<Beer, BeerViewModel>(beer);

            return View();
        }

        // GET: Beer/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(_userApp.GetAll(), "UserID", "Name");

            return View();
        }

        // POST: Beer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeerViewModel beer)
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

        // GET: Beer/Edit/5
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
        public ActionResult Delete(int id)
        {
            var beer = _beerApp.GetById(id);
            var beerViewModel = Mapper.Map<Beer, BeerViewModel>(beer);

            return View(beerViewModel);
        }

        // POST: Beer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var beer = _beerApp.GetById(id);
            _beerApp.Remove(beer);

            return RedirectToAction("Index");
        }
    }
}
