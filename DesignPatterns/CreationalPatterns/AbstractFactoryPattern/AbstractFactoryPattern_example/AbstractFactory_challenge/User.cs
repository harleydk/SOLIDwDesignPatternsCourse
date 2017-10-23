namespace AbstractFactoryPattern
{
    public struct User
    {
        public string UserName { get; private set; }

        public string Password { get; private set; }

        public UserTypeEnum UserType { get; private set; }

        private User(string userName, string password, UserTypeEnum userType)
        {
            UserName = userName;
            Password = password;
            UserType = userType;
        }

        public static User CreateUser(string userName, string password, UserTypeEnum userType)
        {
            User newUser = new User(userName, password, userType);
            return newUser;
        }
    }
}