namespace MiniBlog.Stores;

using Model;

public interface IUserStore
{
    List<User> GetAll();

    User Save(User user);

    bool Delete(User user);
}