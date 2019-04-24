using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Comments
    {

        public int CommentId { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }

        public User User;
        public Story Stories;

    }
}
