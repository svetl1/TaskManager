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
    public class CommentManagementController : Controller
    {
        [HttpGet]
        public ActionResult EditComment(int? creatorid, int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            CommentRepository comrepo = RepositoryFactory.GetCommentRepository();

            Comment comment = null;
            if (id == null)
            {
                comment = new Comment();
                comment.CommenterID = creatorid.Value;
            }
            else comment = comrepo.GetByID(id.Value);

            ViewData["comment"] = comment;

            return View();
        }
        [HttpPost]
        public ActionResult EditComment(Comment comment)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            CommentRepository comrepo = RepositoryFactory.GetCommentRepository();
            comrepo.Save(comment);

            return RedirectToAction("TaskDetails", "TaskManagement", new { id = comment.CommenterID });
        }

        public ActionResult DeleteComment(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            CommentRepository comrepo = RepositoryFactory.GetCommentRepository();
            Comment comment = comrepo.GetByID(id);
            comrepo.Delete(comment);

            return RedirectToAction("TaskDetails", "TaskManagement", new { id = comment.CommenterID });
        }
    }
}