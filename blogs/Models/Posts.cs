using System;
using System.Collections.Generic;

namespace blogs.Models
{
    public partial class Posts
    {
        public Posts()
        {
            Comments = new HashSet<Comments>();
            PostLoves = new HashSet<PostLoves>();
        }

        public int Id { get; set; }
        public int Userid { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Cretime { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<PostLoves> PostLoves { get; set; }
    }
}
