using System;
using System.Linq;
using System.Text;
using blogs.Models;
using blogs.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace blogs.Controllers
{

    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        blogsContext _Context;
        JwtAccessTokenService jwtAccess = new JwtAccessTokenService();
        public UsersController(blogsContext _Context)
        {
            this._Context = _Context;
        }

        [HttpPost]
        [Route("register")] /* [api/users/register] */
        public IActionResult Create([FromBody] Users user)
        {
            try
            {
                user.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Password));
                _Context.Users.Add(user);
                _Context.SaveChanges();
                return Created("", user);
            }
            catch (DbUpdateException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] EntitiesModels.Users user)
        {
            try
            {
                Users _user = new Users();
                _user = _Context.Users.Where(_use => _use.Username == user.Username && _use.Password == Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Password))).Single();
                if (_user == null) return BadRequest(new Exception().Message);

                string token;

                if (user.Remember)
                {
                    token = jwtAccess.GenerateAccessToken(_user, 60 * 24 * 30 * 12);//1 year
                }
                else
                {
                    token = jwtAccess.GenerateAccessToken(_user, 60 * 6); // 6 hours
                }

                AccessToken ac = new AccessToken();
                ac.Token = token;
                ac.Userid = _user.Id;
                _Context.AccessToken.Add(ac);
                _Context.SaveChanges();

                return Ok(new { Access_Token = token, });
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout([FromBody] Users user)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}