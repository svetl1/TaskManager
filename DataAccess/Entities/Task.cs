using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Task:BEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatorID { get; set; }
        public int AssigneeID { get; set; }
        public int Grade { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RecentDate { get; set; }
        public bool Status { get; set; }
    }
}
