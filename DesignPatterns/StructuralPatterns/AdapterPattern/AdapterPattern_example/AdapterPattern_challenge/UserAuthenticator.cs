namespace AdapterPattern
{
    // Our in-house authenticator, custom to our requirements.
    public class UserAuthenticator : IUserAuthenticator
    {
        public bool CanAuthenticate(User user)
        {
            bool canAuthenticateUser = user.Name == "Clint Eastwood" && user.Password == "MakeMyDayPunk" ? true : false;
            return canAuthenticateUser;
        }
    }
}