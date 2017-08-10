using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Comment:BEntity
    {
        public int TaskID { get; set; }
        public int CommenterID { get; set; }
        public string CommentBody { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
