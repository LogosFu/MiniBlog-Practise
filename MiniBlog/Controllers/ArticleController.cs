namespace MiniBlog.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using MiniBlog.Model;
    using MiniBlog.Stores;

    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        [HttpGet]
        public List<Article> List()
        {
            return ArticleStoreWillReplaceInFuture.instance.GetAll();
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            if (article.UserName != null)
            {
                if (!UserStoreWillReplaceInFuture.instance.GetAll().Exists(_ => article.UserName == _.Name))
                {
                    UserStoreWillReplaceInFuture.instance.Save(new User(article.UserName));
                }

                ArticleStoreWillReplaceInFuture.instance.Save(article);
            }

            return Created("/article", article);
        }

        [HttpGet("{id}")]
        public Article GetById(Guid id)
        {
            var foundArticle =
                ArticleStoreWillReplaceInFuture.instance.GetAll().FirstOrDefault(article => article.Id == id);
            return foundArticle;
        }
    }
}