using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RepositoryFactory
    {
        public static UserRepository GetUserRepository()
        {
            string path = ConfigurationManager.AppSettings["dataPath"];
            return new UserRepository(path + @"\users.txt");
        }

        public static TaskRepository GetTaskRepository()
        {
            string path = ConfigurationManager.AppSettings["dataPath"];
            return new TaskRepository(path + @"\contacts.txt");
        }

        public static CommentRepository GetCommentRepository()
        {
            string path = ConfigurationManager.AppSettings["dataPath"];
            return new CommentRepository(path + @"\phones.txt");
        }

        public static LogRepository GetLogRepository()
        {
            string path = ConfigurationManager.AppSettings["dataPath"];
            return new LogRepository(path + @"\phones.txt");
        }
    }
}
