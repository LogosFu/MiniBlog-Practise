namespace MiniBlog.Stores;

using Model;

public interface IArticleStore
{
    Article Save(Article article);

    List<Article> GetAll();

    bool Delete(Article articles);
}