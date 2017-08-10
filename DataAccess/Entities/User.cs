using System;

namespace DataAccess.Entities
{
    public class User:BEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Admin { get; set; }
    }
}
