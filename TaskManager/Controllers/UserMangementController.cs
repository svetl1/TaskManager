using System.Web.Mvc;
using DataAccess.Entities;
using DataAccess.Repository;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class UserManagementController : Controller
    {
        public ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UserRepository usersRepository = RepositoryFactory.GetUserRepository();
            ViewData["users"] = usersRepository.GetAll();

            return View();
        }
        [HttpGet]
        public ActionResult EditUser(int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");
            UserRepository userrepo = RepositoryFactory.GetUserRepository();

            User user = null;
            if (id == null) user = new User();
            else userrepo.GetByID(id.Value);

            ViewData["user"] = user;

            return View();
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if (AuthenticationManager.LoggedUser == null) RedirectToAction("Login", "Home");
            UserRepository usersRepository = RepositoryFactory.GetUserRepository();
            usersRepository.Save(user);

            return RedirectToAction("Index", "UsersManager");
        }

        public ActionResult DeleteUser(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UserRepository usersRepository = RepositoryFactory.GetUserRepository();
            User user = usersRepository.GetByID(id);
            usersRepository.Delete(user);

            return RedirectToAction("Index", "UsersManager");
        }
    }
}