using Xunit;
using blogs.Controllers;
using blogs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace blogs_test
{
    public class BlogsTest:Controller
    {
        UsersController userController;
        public BlogsTest()
        {
            var option = new DbContextOptionsBuilder<blogsContext>()
            .UseInMemoryDatabase(databaseName: "blogs")
            .Options;

            var _context = new blogsContext(option);

            userController = new UsersController(_context);
        }

        public IActionResult CreateUser(Users user)
        {
            IActionResult result = userController.Create(user);
            return result;
        }

        [Fact]
        public void CreateUserShouldReturn201()
        {
            Users user = new Users()
            {
                Fname = "akaporn4",
                Lname = "akaporn",
                Username = "bom",
                Password = "asdf",
                Img = "base64"
            };

            var create = CreateUser(user) as CreatedResult;
            Assert.Equal(create.StatusCode, Created("", null).StatusCode);
        }

        [Fact]
        public void CreateUserShouldReturn404()
        {
            Users user = new Users();

            var BadRequestResult = CreateUser(user) as BadRequestResult;
            Assert.Equal(BadRequestResult.StatusCode, BadRequest().StatusCode);
        }
    }
}
