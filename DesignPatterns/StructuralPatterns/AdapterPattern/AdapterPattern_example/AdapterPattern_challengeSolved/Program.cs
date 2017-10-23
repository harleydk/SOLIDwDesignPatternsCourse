using AdapterPattern;
using System.Diagnostics;

namespace AdapterPattern_challengeSolved
{
    public static class Program
    {
        /// <summary>
        /// By introducing the ThirdPartyAuthenticatorAdapter-class we have effectively wrapped the third-party authenticator, and can now call them in the same fashion.
        /// </summary>
        private static void Main()
        {
            User clint = User.CreateUser("Clint Eastwood", "MakeMyDayPunk");

            IUserAuthenticator inHouseAuthenticator = new UserAuthenticator();
            IUserAuthenticator thirdpartyAuthenticatorAdapter = new ThirdPartyAuthenticatorAdapter();

            if (inHouseAuthenticator.CanAuthenticate(clint) || thirdpartyAuthenticatorAdapter.CanAuthenticate(clint))
                Debug.WriteLine(clint.Name + " can access our site.");
            else
                Debug.WriteLine(clint.Name + " cannot access this website");
        }
    }
}