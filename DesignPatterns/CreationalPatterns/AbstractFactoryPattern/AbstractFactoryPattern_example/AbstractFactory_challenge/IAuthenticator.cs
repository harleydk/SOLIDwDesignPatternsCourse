namespace FactoryPattern
{
    public interface IAuthenticator
    {
        void AuthenticateUser(string userName, string password);
    }
}