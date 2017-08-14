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
    public class LogManagementController : Controller
    {
        [HttpGet]
        public ActionResult EditLog(int? creatorid, int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            LogRepository logrepo = RepositoryFactory.GetLogRepository();

            Log log = null;
            if (id == null)
            {
                log = new Log();
                log.UserID = creatorid.Value;
            }
            else log = logrepo.GetByID(id.Value);

            ViewData["log"] = log;

            return View();
        }
        [HttpPost]
        public ActionResult Editlog(Log log)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            LogRepository comrepo = RepositoryFactory.GetLogRepository();
            comrepo.Save(log);

            return RedirectToAction("TaskDetails", "TaskManagement", new { id = log.UserID });
        }

        public ActionResult DeleteLog(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            LogRepository comrepo = RepositoryFactory.GetLogRepository();
            Log log = comrepo.GetByID(id);
            comrepo.Delete(log);

            return RedirectToAction("TaskDetails", "TaskManagement", new { id = log.UserID });
        }
    }
}