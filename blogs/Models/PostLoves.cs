using System;
using System.Collections.Generic;

namespace blogs.Models
{
    public partial class PostLoves
    {
        public int Userid { get; set; }
        public int Postid { get; set; }

        public virtual Posts Post { get; set; }
        public virtual Users User { get; set; }
    }
}
