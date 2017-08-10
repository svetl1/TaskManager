using System;
using System.IO;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Repository
{
    public class UserRepository : BaseRepository<User>
    {


        public UserRepository(string filepath) : base(filepath)
        {

        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            FileStream fs = new FileStream(this.filepath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    User user = new User();
                    user.ID = Convert.ToInt32(sr.ReadLine());
                    user.FirstName = sr.ReadLine();
                    user.LastName = sr.ReadLine();
                    user.Username = sr.ReadLine();
                    user.Password = sr.ReadLine();
                    user.Admin = Convert.ToBoolean(sr.ReadLine());

                    if (user.Username == username && user.Password == password)
                    {
                        return user;
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return null;
        }

        public override void Reader(StreamReader sr, User item)
        {
            item.ID = Convert.ToInt32(sr.ReadLine());
            item.FirstName = sr.ReadLine();
            item.LastName = sr.ReadLine();
            item.Username = sr.ReadLine();
            item.Password = sr.ReadLine();
            item.Admin = Convert.ToBoolean(sr.ReadLine());
        }

        public override void Writer(StreamWriter sw, User item)
        {
            sw.WriteLine(item.ID);
            sw.WriteLine(item.FirstName);
            sw.WriteLine(item.LastName);
            sw.WriteLine(item.Username);
            sw.WriteLine(item.Password);
            sw.WriteLine(item.Admin);
        }
    }
}