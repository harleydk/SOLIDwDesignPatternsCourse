namespace AdapterPattern
{
    /// <summary>
    /// The adapter wraps, and makes calls to, an instance of the wrapped, adapted object.
    /// </summary>
    public sealed class ThirdPartyAuthenticatorAdapter : IUserAuthenticator
    {
        private readonly IThirdPartyAuthenticator _thirdpartyAuthenticator;

        public ThirdPartyAuthenticatorAdapter()
        {
            _thirdpartyAuthenticator = new ThirdPartyAuthenticator();
        }

        public bool CanAuthenticate(User user)
        {
            _thirdpartyAuthenticator.StoreCredentials(user.Name, user.Password);
            bool tryToAuthenticate = _thirdpartyAuthenticator.TryToAuthenciate();
            return tryToAuthenticate;
        }
    }
}