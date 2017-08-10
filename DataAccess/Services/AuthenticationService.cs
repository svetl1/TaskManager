using DataAccess.Entities;
using DataAccess.Repository;

namespace DataAccess.Services
{
   public class AuthenticationService
    {
        public User LoggedUser { get; private set; }

        public void AuthenticateUser(string username, string password)
        {
            UserRepository userrepo = RepositoryFactory.GetUserRepository();
            LoggedUser = userrepo.GetByUsernameAndPassword(username, password);
        }
    }
}
