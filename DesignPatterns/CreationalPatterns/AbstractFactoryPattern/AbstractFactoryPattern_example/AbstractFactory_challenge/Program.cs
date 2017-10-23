namespace AbstractFactoryPattern
{
    /// <summary>
    /// The challenge is this: Implement a solution by way of the abstract factory pattern, as per the concept-project.
    /// </summary>
    ///
    public sealed class Program
    {
        public static void Main()
        {
            var basicUser = User.CreateUser("Arnold Schwarzenegger", "IllBeBack", UserTypeEnum.BasicUser);
            UserSecurityManager userSecurityManager = new UserSecurityManager(basicUser.UserType);
            userSecurityManager.PerformUserSecurityOperations(basicUser);

            var superUser = User.CreateUser("Clint Eastwood", "MakeMyDayPunk", UserTypeEnum.SuperUser);
            userSecurityManager = new UserSecurityManager(superUser.UserType);
            userSecurityManager.PerformUserSecurityOperations(superUser);

            // Lab1: Implement the design pattern-solution, instead of the below code-smelly one.
        }
    }
}