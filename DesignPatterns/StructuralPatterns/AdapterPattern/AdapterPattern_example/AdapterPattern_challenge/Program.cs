using AdapterPattern;

namespace AdapterPattern_problem
{
    public static class Program
    {
        /// <summary>
        /// Challenge: implement the adapter pattern to wrap the thirdparty-authenticator and force it to behave like an IUserAuthenticator implementation.
        /// </summary>
        public static void Main()
        {
            User clint = User.CreateUser("Clint Eastwood", "MakeMyDayPunk");

            // Perform authentication by our two authenticators, adhering to the same interface.

            /*#
            IUserAuthenticator inHouseAuthenticator = new UserAuthenticator();
            if (inHouseAuthenticator.CanAuthenticate(clint))
                Debug.WriteLine(clint.Name + " can access our site.");

             *
             * else
            {
                // Go through the motions of the third-party authenticator, somewhat different to our in-house one.
                ThirdPartyAuthenticator thirdpartyAuthenticator = new ThirdPartyAuthenticator();
                thirdpartyAuthenticator.StoreCredentials(clint.Name, clint.Password);

                // ... and try to authenticate using them both
                if (thirdpartyAuthenticator.TryToAuthenciate())
                    Debug.WriteLine(clint.Name + " can access this website");
                else
                    Debug.WriteLine(clint.Name + " cannot access this website");
            }*/
        }
    }
}