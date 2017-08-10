using DataAccess.Entities;
using DataAccess.Repository;
using TaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManager.Controllers
{
    public class TaskManagementController : Controller
    {
        public ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TaskRepository taskrepository = RepositoryFactory.GetTaskRepository();
            ViewData["tasks"] = taskrepository.GetAllWithID(AuthenticationManager.LoggedUser.ID);

            return View();
        }
    }
}