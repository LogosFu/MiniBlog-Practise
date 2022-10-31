namespace MiniBlog.Stores
{
    using Model;

    public class UserStoreWillReplaceInFuture
    {
        private UserStoreWillReplaceInFuture()
        {
            Init();
        }

        public static readonly UserStoreWillReplaceInFuture instance = new();

        public List<User> Users { get; private set; }

        public void Init()
        {
            Users = new List<User>();
        }
    }
}