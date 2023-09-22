namespace AbstractFactoryPattern
{
    public struct User(string userName, string password, UserTypeEnum userType)
    {
        public string UserName { get; private set; } = userName;

        public string Password { get; private set; } = password;

        public UserTypeEnum UserType { get; private set; } = userType;

        public static User CreateUser(string userName, string password, UserTypeEnum userType)
        {
            User newUser = new(userName, password, userType);
            return newUser;
        }
    }
}