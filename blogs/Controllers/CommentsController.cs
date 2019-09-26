using System;
using System.Linq;
using blogs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace blogs.Controllers
{
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        blogsContext _Context;

        public CommentsController(blogsContext _Context)
        {
            this._Context = _Context;
        }

        public IActionResult CreateComment([FromBody] Comments comment)
        {
            try
            {
                this._Context.Comments.Add(comment);
                this._Context.SaveChanges();
                return Ok();
            }catch(Exception e){
                return BadRequest();
            }
        }

        public IActionResult GetComment(){
            return Ok();
        }
    }
}