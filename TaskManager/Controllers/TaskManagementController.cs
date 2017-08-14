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

        public ActionResult TaskDetails(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TaskRepository taskrepo = RepositoryFactory.GetTaskRepository();
            CommentRepository comrepo = RepositoryFactory.GetCommentRepository();

            ViewData["task"] = taskrepo.GetByID(id);
            ViewData["comments"] = comrepo.GetAll(id);
            return View();
        }
        [HttpGet]
        public ActionResult EditTask(int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TaskRepository taskrepo = RepositoryFactory.GetTaskRepository();

            Task task = null;
            if (id == null)
            {
                task = new Task();
                task.CreatorID = AuthenticationManager.LoggedUser.ID;
            }
            else task = taskrepo.GetByID(id.Value);

            ViewData["task"] = task;

            return View();
        }
        [HttpPost]
        public ActionResult EditTask(Task task)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TaskRepository taskrepo = RepositoryFactory.GetTaskRepository();
            taskrepo.Save(task);

            return RedirectToAction("Index", "ContactsManager");
        }

        public ActionResult DeleteTask(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TaskRepository taskrepo = RepositoryFactory.GetTaskRepository();
            Task task = taskrepo.GetByID(id);
            taskrepo.Delete(task);

            return RedirectToAction("Index", "ContactsManager");
        }
    }
}