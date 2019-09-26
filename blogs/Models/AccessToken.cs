using System;
using System.Collections.Generic;

namespace blogs.Models
{
    public partial class AccessToken
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public string Token { get; set; }

        public virtual Users User { get; set; }
    }
}
