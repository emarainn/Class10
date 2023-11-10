﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class10.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set;}

        // Navigation Properties
        public virtual List<Post> Posts { get; set;}
    }
}
