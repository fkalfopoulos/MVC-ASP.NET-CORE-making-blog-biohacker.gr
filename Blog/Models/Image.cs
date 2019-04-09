using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{

    public class Image
    {

        [StringLength(50)]
        [Required]
        public string Name { get; set; }


        [StringLength(4)]
        [Required]
        public string Extension { get; set; }

    }
}