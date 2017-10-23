using FactoryPattern;

namespace AbstractFactoryPattern
{
    public sealed class UserSecurityManager
    {
        private IAuthorizer _authorizer;
        private IAuthenticator _authenticator;

        public UserSecurityManager(ISecurityProviderFactory securityProviderFactory)
        {
            _authorizer = securityProviderFactory.CreateAuthorizer();
            _authenticator = securityProviderFactory.CreateAuthenticator();
        }

        public void PerformUserSecurityOperations(User user)
        {
            // authenticate user
            _authenticator.AuthenticateUser(user.UserName, user.Password);

            // authorize user
            bool canUserBeAuthorized = _authorizer.CanAuthorizeUser(user.UserName);
            if (canUserBeAuthorized)

                _authorizer.AuthorizeUser(user.UserName);
        }
    }
}