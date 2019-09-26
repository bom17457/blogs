using System.Collections.Generic;
using System.Linq;
using blogs.Models;
using Microsoft.AspNetCore.Mvc;

namespace NamespaceName
{

    [Route("api/post")]

    public class PostsController : Controller
    {
        blogsContext _Context;

        public PostsController(blogsContext _Context)
        {
            this._Context = _Context;
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreatePost([FromBody] Posts posts)
        {
            _Context.Posts.Add(posts);
            _Context.SaveChanges();
            return Created("", null);
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetPost([FromHeader] int id)
        {
            List<VIEW_POST> post = new List<VIEW_POST>();
            post = _Context.VIEW_POST.Where(pos => pos.LoginID == id).ToList();
            return Ok(post);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPostById(int id, [FromHeader] Users users)
        {
            VIEW_POST post = new VIEW_POST();
            post = _Context.VIEW_POST.Where(pos => pos.Id == id & pos.LoginID == users.Id).Single();
            return Ok(post);
        }

        [HttpPut]
        [Route("")]
        public IActionResult EditPost([FromBody] Posts posts)
        {
            _Context.Posts.Update(posts);
            _Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePost(int id)
        {
            Posts _post = new Posts();
            _post = _Context.Posts.Where(post => post.Id == id).Single();
            _Context.Posts.Remove(_post);
            _Context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("/love")]
        public IActionResult LovePost([FromBody] PostLoves PostLoves)
        {
            _Context.PostLoves.Add(PostLoves);
            _Context.SaveChanges();
            return Created("", null);
        }

        [HttpPost]
        [Route("/unlove")]
        public IActionResult UnLovePost([FromBody] PostLoves PostLoves)
        {
            _Context.Remove(PostLoves);
            _Context.SaveChanges();
            return Ok();
        }
    }
}