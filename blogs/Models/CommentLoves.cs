using System;
using System.Collections.Generic;

namespace blogs.Models
{
    public partial class CommentLoves
    {
        public int Userid { get; set; }
        public int Commentid { get; set; }

        public virtual Comments Comment { get; set; }
        public virtual Users User { get; set; }
    }
}
