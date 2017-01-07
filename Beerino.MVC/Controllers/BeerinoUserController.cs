using AutoMapper;
using Beerino.Application.Interface;
using Beerino.Domain.Entities;
using Beerino.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web.Mvc;

namespace Beerino.MVC.Controllers
{
    public class BeerinoUserController : Controller
    {
        private readonly IBeerinoUserAppService _beerinoUserApp;
        private readonly IUserAppService _userApp;
        private readonly IBeerAppService _beerApp;
        private readonly ITaskBeerAppService _taskBeerApp;

        public BeerinoUserController(IBeerinoUserAppService beerinoUserApp, IUserAppService userApp, IBeerAppService beerApp, ITaskBeerAppService taskBeerApp)
        {
            _beerinoUserApp = beerinoUserApp;
            _userApp = userApp;
            _beerApp = beerApp;
            _taskBeerApp = taskBeerApp;
        }

        // GET: BeerinoUser
        [Authorize]
        public ActionResult Index()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var EmailAddress = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            int userId = _userApp.GetIdByEmail(EmailAddress);

            var beerinoUserViewModel = Mapper.Map<IEnumerable<BeerinoUser>, IEnumerable<BeerinoUserViewModel>>(_beerinoUserApp.getBeerinoByUser(userId));

            return View(beerinoUserViewModel);
        }

        // GET: BeerinoUser/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var beerinoUser = _beerinoUserApp.GetById(id);
            var beerinoUserViewModel = Mapper.Map<BeerinoUser, BeerinoUserViewModel>(beerinoUser);

            return View(beerinoUserViewModel);
        }

        // GET: BeerinoUser/Create
        [Authorize]
        public ActionResult Create()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var EmailAddress = claimsIdentity?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            
            ViewBag.BeerID = new SelectList(_beerApp.GetAll(), "BeerID", "Name");

            return View(new BeerinoUserViewModel());
        }

        // POST: BeerinoUser/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(BeerinoUserViewModel beerino)
        {
            if (ModelState.IsValid)
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                var EmailAddress = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                int userId = _userApp.GetIdByEmail(EmailAddress);

                beerino.UserID = Convert.ToInt32(userId);

                var beerinoUserDomain = Mapper.Map<BeerinoUserViewModel, BeerinoUser>(beerino);
                _beerinoUserApp.Add(beerinoUserDomain);

                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(_userApp.GetAll(), "UserID", "Name", beerino.UserID);
            ViewBag.BeerID = new SelectList(_beerApp.GetAll(), "BeerID", "Name", beerino.BeerID);

            return View(beerino);
        }

        // GET: BeerinoUser/Edit/5
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        public ActionResult Delete(int id)
        {
            var beerino = _beerinoUserApp.GetById(id);
            var beerinoViewModel = Mapper.Map<BeerinoUser, BeerinoUserViewModel>(beerino);

            return View(beerinoViewModel);
        }

        // POST: BeerinoUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var beerino = _beerinoUserApp.GetById(id);
            _beerinoUserApp.Remove(beerino);

            return RedirectToAction("Index");
        }

        public ActionResult getTaskBeer(string id)
        {
            /*
             * Recebe parametros do seguinte formato BeerinoID-TaskOrder (se não tiver processo enviar 0)
             * http://localhost:53662/BeerinoUser/getTaskBeer/1-0
             *  Dar split no data, separar BeerinoUserId e TaskOrder;
             *  Se TaskAtual for 0, busca primeira Task da ordem
             *  Se não buscar proxima task depois da taskatual
             *  Se não tiver cerveja cadastrada solicitar cadastro
             */

            var listStrLineElements = id.Split('-').ToList();

            TaskBeer task = new TaskBeer();
            var beerId = _beerinoUserApp.GetById(Convert.ToInt32(listStrLineElements[0])).BeerID;
            int actualTaskBeerOrder = Convert.ToInt32(listStrLineElements[1]);

            if (beerId == null)
            {
                return Content("Cadastrar Cernveja no Beerino");
            }
            else
            {
                task = _taskBeerApp.getNextTaskBeer((int)beerId, actualTaskBeerOrder);
            }

            if (task == null)
            {
                return Content("Fim dos Processos");
            }

            // TaskOrder/Tempo/TemperaturaMinima/TemperaturaMaxima
            return Content($"{task.Order}/{TimeSpan.FromMinutes(task.Time).TotalMilliseconds}/{task.Temperature - 2}/{task.Temperature + 2}");
        }

        public ActionResult setTemperature(string id)
        {
            /* Adiciona a temperatura atual do Beerino setTemperature/idBeerino-temperatura
             * http://localhost:53662/BeerinoUser/setTemperature/1-0
             */
            try
            {
                var listStrLineElements = id.Split('-').ToList();

                TaskBeer task = new TaskBeer();
                var beerino = _beerinoUserApp.GetById(Convert.ToInt32(listStrLineElements[0]));
                beerino.ActualTemperature = Convert.ToInt32(listStrLineElements[1]);

                _beerinoUserApp.Update(beerino);
            }
            catch (Exception)
            {

                return Content("Error");
            }            

            return Content("Success");
        }
    }
}
