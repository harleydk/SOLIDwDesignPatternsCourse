namespace FactoryPattern
{
    public interface IAuthorizer
    {
        bool CanAuthorizeUser(string username);

        void AuthorizeUser(string userName);
    }
}