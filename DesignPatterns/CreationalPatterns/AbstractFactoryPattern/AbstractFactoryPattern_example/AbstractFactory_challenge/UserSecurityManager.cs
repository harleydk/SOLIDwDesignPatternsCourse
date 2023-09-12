using FactoryPattern;

namespace AbstractFactoryPattern
{
    public sealed class UserSecurityManager
    {
        private readonly IAuthorizer _authorizer;
        private readonly IAuthenticator _authenticator;

        public UserSecurityManager(UserTypeEnum userType)
        {
            if (userType == UserTypeEnum.BasicUser)
            {
                _authenticator = new BasicUserAuthenticator();
                _authorizer = new BasicUserAuthorizer();
            }
            else if (userType == UserTypeEnum.SuperUser)
            {
                _authenticator = new SuperUserAuthenticator();
                _authorizer = new SuperUserAuthorizer();
            }
            else
                throw new ArgumentException("No such user-type");
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