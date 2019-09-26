using System;
using System.Collections.Generic;

namespace blogs.Models
{
    public partial class Comments
    {
        public Comments()
        {
            CommentLoves = new HashSet<CommentLoves>();
        }

        public int Id { get; set; }
        public int Userid { get; set; }
        public int Postsid { get; set; }
        public string Content { get; set; }
        public DateTime Cretime { get; set; }

        public virtual Posts Posts { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<CommentLoves> CommentLoves { get; set; }
    }
}
