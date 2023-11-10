﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class10.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        // Navigation Properties
        public virtual int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
