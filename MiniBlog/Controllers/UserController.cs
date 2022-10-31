using MiniBlog.Model;
using MiniBlog.Stores;
using Microsoft.AspNetCore.Mvc;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public ActionResult<User> Register(User user)
        {
            if (!UserStoreWillReplaceInFuture.instance.GetAll().Exists(_ => user.Name.ToLower() == _.Name.ToLower()))
            {
                UserStoreWillReplaceInFuture.instance.Save(user);
            }

            return Created("/user", user);
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return UserStoreWillReplaceInFuture.instance.GetAll();
        }

        [HttpPut]
        public User Update(User user)
        {
            var foundUser = UserStoreWillReplaceInFuture.instance.GetAll().FirstOrDefault(_ => _.Name == user.Name);
            if (foundUser != null)
            {
                foundUser.Email = user.Email;
            }

            return foundUser;
        }

        [HttpDelete]
        public User Delete(string name)
        {
            var foundUser = UserStoreWillReplaceInFuture.instance.GetAll().FirstOrDefault(_ => _.Name == name);
            if (foundUser != null)
            {
                UserStoreWillReplaceInFuture.instance.Delete(foundUser);
                var articles = ArticleStoreWillReplaceInFuture.instance.GetAll()
                    .Where(article => article.UserName == foundUser.Name)
                    .ToList();
                articles.ForEach(article => ArticleStoreWillReplaceInFuture.instance.Delete(article));
            }

            return foundUser;
        }

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            return UserStoreWillReplaceInFuture.instance.GetAll().FirstOrDefault(_ =>
                string.Equals(_.Name, name, StringComparison.CurrentCultureIgnoreCase)) ?? throw new
                InvalidOperationException();
        }
    }
}