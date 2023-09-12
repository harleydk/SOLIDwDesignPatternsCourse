namespace FactoryPattern
{
    public sealed class BasicUserAuthorizer : IAuthorizer
    {
        public bool CanAuthorizeUser(string userName)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(userName), "user-name should not be null or whitespace");

            bool canAuthorizeUser = userName != "Clint Eastwood";
            Debug.WriteLine($"{this.GetType().Name}: Can we authorize {userName}? {canAuthorizeUser}");
            return canAuthorizeUser;
        }

        void IAuthorizer.AuthorizeUser(string userName)
        {
            Debug.WriteLine($"{this.GetType().Name}: Prentending to authorize user {userName}...");
        }
    }
}