namespace MiniBlog.Service;

using Model;
using Stores;

public class ArticleService : IArticleService
{
    private IArticleStore articleStore;
    private IUserStore userStore;

    public ArticleService(IArticleStore articleStore, IUserStore userStore)
    {
        this.articleStore = articleStore;
        this.userStore = userStore;
    }

    public Article Create(Article article)
    {
        if (article.UserName != null)
        {
            if (!this.userStore.GetAll().Exists(_ => article.UserName == _.Name))
            {
                this.userStore.Save(new User(article.UserName));
            }

            articleStore.Save(article);
        }

        return article;
    }
}