using System;

namespace blogs.Models
{
    public partial class VIEW_POST
    {
        public int Id { get; set; }
        public int WriterID { get; set; }
        public string WriterFName { get; set; }
        public string WriterLname { get; set; }
        public int LoginID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CountLove { get; set; }
        public string Userlove { get; set; }
        public DateTime Cretime { get; set; }
    }
}