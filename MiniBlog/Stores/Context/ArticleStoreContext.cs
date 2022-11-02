namespace MiniBlog.Stores;

using Model;

public class ArticleStoreContext : IArticleStore
{
    private List<Article> articles = new List<Article>();

    public Article Save(Article article)
    {
        articles.Add(article);
        return article;
    }

    public List<Article> GetAll()
    {
        return articles;
    }

    public bool Delete(Article article)
    {
        return articles.Remove(article);
    }
}