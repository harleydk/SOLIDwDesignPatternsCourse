namespace AbstractFactoryPattern
{
    public sealed class Program
    {
        /// <summary>
        /// By introducing an abstract factory that creates the appropriate authenticator and authorizer objects as per the designated user-type, we have factored out that which changes into a component in its own right, 
        /// and can the more easily maintain it - for example by introducing a new user-type.
        /// </summary>
        public static void Main()
        {
            User basicUser = User.CreateUser("Arnold Schwarzenegger", "IllBeBack", UserTypeEnum.BasicUser);
            ISecurityProviderFactory securityProviderFactory = GetSecurityProviderFactory(basicUser.UserType);
            UserSecurityManager userSecurityManager = new(securityProviderFactory);
            userSecurityManager.PerformUserSecurityOperations(basicUser);

            User superUser = User.CreateUser("Clint Eastwood", "MakeMyDayPunk", UserTypeEnum.SuperUser);
            securityProviderFactory = GetSecurityProviderFactory(superUser.UserType);
            userSecurityManager = new UserSecurityManager(securityProviderFactory);
            userSecurityManager.PerformUserSecurityOperations(basicUser);
        }

        /// <summary>
        ///  Our securityProviderFactory groups object-creation of a set of classes of a common theme.
        /// </summary>
        private static ISecurityProviderFactory GetSecurityProviderFactory(UserTypeEnum userType)
        {
            if (userType == UserTypeEnum.SuperUser)
                return new SuperUserSecurityProviderFactory();
            else if (userType == UserTypeEnum.BasicUser)
                return new BasicUserSecurityProviderFactory();
            else
                throw new ArgumentException($"Unknown user-type {userType}");
        }
    }
}