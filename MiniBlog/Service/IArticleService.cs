namespace MiniBlog.Service;

using Model;

public interface IArticleService
{
    Article Create(Article article);
}