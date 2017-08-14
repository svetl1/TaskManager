using TaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            AuthenticationManager.Authenticate(username, password);

            if (AuthenticationManager.LoggedUser == null)
            {
                ModelState.AddModelError("AuthenticationFailed", "Wrong username or password!");
                ViewData["username"] = username;

                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            AuthenticationManager.Logout();

            return RedirectToAction("Login", "Home");
        }
    }
}