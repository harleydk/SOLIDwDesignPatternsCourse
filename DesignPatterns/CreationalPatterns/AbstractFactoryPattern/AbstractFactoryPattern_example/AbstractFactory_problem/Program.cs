namespace AbstractFactoryPattern_beforePattern
{
    public sealed partial class Program
    {
        /// <summary>
        /// For different user-types, basic- or super-user, we need to use a different set of authenticator/authorizer. So in the 'UserSecurityManager'-class, we switch on user-types and instantiate the appropriate authenticator and authorizer objects as needed. This works, but has the code-smell to it... New user-type permutations will have us open up this code again and then some.
        /// </summary>
        public static void Main()
        {
            var basicUser = User.CreateUser("Arnold Schwarzenegger", "IllBeBack", UserTypeEnum.BasicUser);
            UserSecurityManager userSecurityManager = new UserSecurityManager(basicUser.UserType);
            userSecurityManager.PerformUserSecurityOperations(basicUser);

            var superUser = User.CreateUser("Clint Eastwood", "MakeMyDayPunk", UserTypeEnum.SuperUser);
            userSecurityManager = new UserSecurityManager(superUser.UserType);
            userSecurityManager.PerformUserSecurityOperations(superUser);

            // Lab1: Implement the design pattern-solution; create an abstract factory that facilitates the instantiational logic.
        }
    }
}