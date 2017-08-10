using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Log:BEntity
    {
        public int TaskID { get; set; }
        public int UserID { get; set; }
        public int Hours { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
