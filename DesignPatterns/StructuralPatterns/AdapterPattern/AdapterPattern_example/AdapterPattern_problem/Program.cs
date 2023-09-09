using AdapterPattern;
using System.Diagnostics;

namespace AdapterPattern_problem
{
    public static class Program
    {
        /// <summary>
        /// Here we have two user authenticators that we need to run together, since we just purchased a competitor's site. They are, however, incompatible in their methods.
        /// </summary>
        public static void Main()
        {
            User clint = User.CreateUser("Clint Eastwood", "MakeMyDayPunk");

            IUserAuthenticator inHouseAuthenticator = new UserAuthenticator();
            if (inHouseAuthenticator.CanAuthenticate(clint))
                Debug.WriteLine(clint.Name + " can access our site.");
            else
            {
                // Go through the motions of the third-party authenticator, somewhat different to our in-house one.
                ThirdPartyAuthenticator thirdpartyAuthenticator = new();
                thirdpartyAuthenticator.StoreCredentials(clint.Name, clint.Password);

                // ... and try to authenticate using them both
                if (thirdpartyAuthenticator.TryToAuthenciate())
                    Debug.WriteLine(clint.Name + " can access this website");
                else
                    Debug.WriteLine(clint.Name + " cannot access this website");
            }
        }

        // This feels inflexible, like a code-smell. The Adapter Pattern solves the problem.
    }
}