using FactoryPattern;
using System;

namespace AbstractFactoryPattern
{
    public sealed class UserSecurityManager
    {
        private IAuthorizer _authorizer;
        private IAuthenticator _authenticator;

        public UserSecurityManager(UserTypeEnum userType)
        {
            if (userType == UserTypeEnum.BasicUser)
            {
                IAuthenticator authenticator = new BasicUserAuthenticator();
                IAuthorizer authorizer = new BasicUserAuthorizer();
            }
            else if (userType == UserTypeEnum.SuperUser)
            {
                IAuthenticator authenticator = new SuperUserAuthenticator();
                IAuthorizer authorizer = new SuperUserAuthorizer();
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