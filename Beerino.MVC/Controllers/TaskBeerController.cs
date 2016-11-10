using AutoMapper;
using Beerino.Application.Interface;
using Beerino.Domain.Entities;
using Beerino.MVC.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TaskBeerino.MVC.Controllers
{
    public class TaskBeerController : Controller
    {
        private readonly ITaskBeerAppService _taskBeerApp;
        private readonly IBeerAppService _beerApp;

        public TaskBeerController(ITaskBeerAppService taskBeerApp, IBeerAppService beerApp)
        {
            _taskBeerApp = taskBeerApp;
            _beerApp = beerApp;
        }

        // GET: TaskBeer
        [Authorize]
        public ActionResult Index()
        {
            var taskBeerModelView = Mapper.Map<IEnumerable<TaskBeer>, IEnumerable<TaskBeerViewModel>>(_taskBeerApp.GetAll());

            return View(taskBeerModelView);
        }

        // GET: TaskBeer/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var taskBeer = _taskBeerApp.GetById(id);
            var taskBeerViewModel = Mapper.Map<TaskBeer, TaskBeerViewModel>(taskBeer);

            return View();
        }

        // GET: TaskBeer/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.BeerID = new SelectList(_beerApp.GetAll(), "BeerID", "Name");

            return View();
        }

        // POST: TaskBeer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(TaskBeerViewModel taskBeer)
        {
            if (ModelState.IsValid)
            {
                var taskBeerDomain = Mapper.Map<TaskBeerViewModel, TaskBeer>(taskBeer);
                _taskBeerApp.Add(taskBeerDomain);

                return RedirectToAction("Index");
            }

            ViewBag.BeerID = new SelectList(_beerApp.GetAll(), "BeerID", "Name", taskBeer.BeerID);

            return View(taskBeer);
        }

        // GET: TaskBeer/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var taskBeer = _taskBeerApp.GetById(id);
            var taskBeerViewModel = Mapper.Map<TaskBeer, TaskBeerViewModel>(taskBeer);

            ViewBag.BeerID = new SelectList(_beerApp.GetAll(), "BeerID", "Name", taskBeer.BeerID);

            return View(taskBeerViewModel);
        }

        // POST: TaskBeer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(TaskBeerViewModel taskBeer)
        {
            if (ModelState.IsValid)
            {
                var taskBeerDomain = Mapper.Map<TaskBeerViewModel, TaskBeer>(taskBeer);
                _taskBeerApp.Add(taskBeerDomain);

                return RedirectToAction("Index");
            }

            ViewBag.BeerID = new SelectList(_beerApp.GetAll(), "BeerID", "Name", taskBeer.BeerID);

            return View(taskBeer);
        }

        // GET: TaskBeer/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var taskBeer = _taskBeerApp.GetById(id);
            var taskBeerViewModel = Mapper.Map<TaskBeer, TaskBeerViewModel>(taskBeer);

            return View(taskBeerViewModel);
        }

        // POST: TaskBeer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var taskBeer = _taskBeerApp.GetById(id);
            _taskBeerApp.Remove(taskBeer);

            return RedirectToAction("Index");
        }
    }
}
