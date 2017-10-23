namespace AdapterPattern
{
    public interface IUserAuthenticator
    {
        bool CanAuthenticate(User user);
    }
}