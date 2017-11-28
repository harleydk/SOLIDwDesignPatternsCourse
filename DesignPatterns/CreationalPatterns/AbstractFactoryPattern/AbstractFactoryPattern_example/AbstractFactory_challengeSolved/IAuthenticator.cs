namespace AbstractFactoryPattern
{
    public interface IAuthenticator
    {
        void AuthenticateUser(string userName, string password);
    }
}