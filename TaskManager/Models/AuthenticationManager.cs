using DataAccess.Services;
using DataAccess.Entities;
using System.Web;

namespace TaskManager.Models
{
    public static class AuthenticationManager
    {
        public static User LoggedUser
        {
            get
            {
                AuthenticationService authserv = null;

                if (HttpContext.Current != null && HttpContext.Current.Session["LoggedUser"] == null) HttpContext.Current.Session["LoggedUser"] = new AuthenticationService();

                authserv = (AuthenticationService)HttpContext.Current.Session["LoggedUser"];
                return authserv.LoggedUser;
            }
        }

        public static void Authenticate(string username, string pass)
        {
            AuthenticationService authserv = null;

            if (HttpContext.Current != null && HttpContext.Current.Session["LoggedUser"] == null) HttpContext.Current.Session["LoggedUser"] = new AuthenticationService();

            authserv = (AuthenticationService)HttpContext.Current.Session["LoggedUser"];
            authserv.AuthenticateUser(username, pass);
        }

        public static void Logout()
        {
            HttpContext.Current.Session["LoggedUser"] = null;
        }
    }
}