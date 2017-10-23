namespace AdapterPattern
{
    public struct User
    {
        public string Name { get; private set; }

        public string Password { get; private set; }

        private User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public static User CreateUser(string name, string password)
        {
            User newUser = new User(name, password);
            return newUser;
        }
    }
}