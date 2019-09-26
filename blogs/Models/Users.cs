using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace blogs.Models
{
    public partial class Users
    {
        public Users()
        {
            AccessToken = new HashSet<AccessToken>();
            CommentLoves = new HashSet<CommentLoves>();
            Comments = new HashSet<Comments>();
            PostLoves = new HashSet<PostLoves>();
            Posts = new HashSet<Posts>();
        }

        [Key]
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Img { get; set; }
        public string Type { get; set; }

        public virtual ICollection<AccessToken> AccessToken { get; set; }
        public virtual ICollection<CommentLoves> CommentLoves { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<PostLoves> PostLoves { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
