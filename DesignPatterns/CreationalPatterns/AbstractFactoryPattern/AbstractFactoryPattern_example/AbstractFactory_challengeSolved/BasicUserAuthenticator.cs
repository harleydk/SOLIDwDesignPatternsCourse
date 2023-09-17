using System.Diagnostics;

namespace AbstractFactoryPattern
{
    public class BasicUserAuthenticator : IAuthenticator
    {
        public void AuthenticateUser(string userName, string password)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(userName), "user-name should not be null or whitespace");
            Debug.Assert(!string.IsNullOrWhiteSpace(password), "password should not be null or whitespace");

            bool isBasicUser = (userName != "Clint Eastwood" ? true : false);
            Debug.WriteLine($"{this.GetType().Name}: {userName} is basic user? {isBasicUser}");
        }
    }
}