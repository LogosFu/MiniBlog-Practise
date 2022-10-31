﻿namespace MiniBlog.Controllers
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
            return ArticleStoreWillReplaceInFuture.instance.Articles;
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            if (article.UserName != null)
            {
                if (!UserStoreWillReplaceInFuture.instance.Users.Exists(_ => article.UserName == _.Name))
                {
                    UserStoreWillReplaceInFuture.instance.Users.Add(new User(article.UserName));
                }

                ArticleStoreWillReplaceInFuture.instance.Articles.Add(article);
            }

            return Created("/article", article);
        }

        [HttpGet("{id}")]
        public Article GetById(Guid id)
        {
            var foundArticle =
                ArticleStoreWillReplaceInFuture.instance.Articles.FirstOrDefault(article => article.Id == id);
            return foundArticle;
        }
    }
}