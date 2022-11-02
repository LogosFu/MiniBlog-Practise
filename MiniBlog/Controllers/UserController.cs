using MiniBlog.Model;
using MiniBlog.Stores;
using Microsoft.AspNetCore.Mvc;

namespace MiniBlog.Controllers
{
    using Service;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public ActionResult<User> Register(User user)
        {
            return Created("/user", userService.Register(user));
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return userService.GetAll();
        }

        [HttpPut]
        public User Update(User user)
        {
            return this.userService.Update(user);
        }

        [HttpDelete]
        public User Delete(string name)
        {
            return this.userService.Delete(name);
        }

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            return this.userService.GetByName(name);
        }
    }
}