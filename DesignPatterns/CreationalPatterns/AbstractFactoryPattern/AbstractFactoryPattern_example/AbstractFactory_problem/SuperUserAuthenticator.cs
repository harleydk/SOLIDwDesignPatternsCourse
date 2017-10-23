using System.Diagnostics;

namespace FactoryPattern
{
    public class SuperUserAuthenticator : IAuthenticator
    {
        public void AuthenticateUser(string userName, string password)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(userName), "user-name should not be null or whitespace");
            Debug.Assert(!string.IsNullOrWhiteSpace(password), "password should not be null or whitespace");

            bool isSuperUser = (userName == "Clint Eastwood" && password == "MakeMyDayPunk" ? true : false);
            Debug.WriteLine($"{this.GetType().Name}: {userName} is super user? {isSuperUser}");

            if (!isSuperUser)
                throw new System.Security.SecurityException("Bad username/password combination");
        }
    }
}