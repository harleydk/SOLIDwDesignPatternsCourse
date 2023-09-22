namespace AbstractFactoryPattern
{
    public sealed class UserSecurityManager(ISecurityProviderFactory securityProviderFactory)
    {
        private readonly IAuthorizer _authorizer = securityProviderFactory.CreateAuthorizer();
        private readonly IAuthenticator _authenticator = securityProviderFactory.CreateAuthenticator();

      
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