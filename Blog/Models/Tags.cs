﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string Name { get; set; }

    }
}
