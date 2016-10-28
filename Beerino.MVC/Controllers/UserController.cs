using AutoMapper;
using Beerino.Application.Interface;
using Beerino.Domain.Entities;
using Beerino.MVC.ViewModel;
using System.Collections.Generic;
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

        public ActionResult Index()
        {
            var userViewModel = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(_userApp.GetAll());

            return View(userViewModel);
        }

        public ActionResult Especiais()
        {
            var userViewModel = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(_userApp.getSpecialUsers());

            return View(userViewModel);
        }

        public ActionResult Details(int id)
        {
            var user = _userApp.GetById(id);
            var userViewModel = Mapper.Map<User, UserViewModel>(user);

            return View(userViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        public ActionResult Edit(int id)
        {
            var user = _userApp.GetById(id);
            var userViewModel = Mapper.Map<User, UserViewModel>(user);

            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        public ActionResult Delete(int id)
        {
            var user = _userApp.GetById(id);
            var userViewModel = Mapper.Map<User, UserViewModel>(user);

            return View(userViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = _userApp.GetById(id);
            _userApp.Remove(user);

            return RedirectToAction("Index");
        }
    }
}
