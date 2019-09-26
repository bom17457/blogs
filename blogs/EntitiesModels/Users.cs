using System;

namespace blogs.EntitiesModels
{
    public class Users : blogs.Models.Users
    {
        public bool Remember { get; set; }
        public DateTime Exp { get; set; }
    }
}