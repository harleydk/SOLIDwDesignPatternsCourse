namespace AbstractFactoryPattern
{
    public sealed class BasicUserSecurityProviderFactory : ISecurityProviderFactory
    {
        public IAuthenticator CreateAuthenticator()
        {
            return new BasicUserAuthenticator(); // note, we could - should? - derive these from the use of DI.
        }

        public IAuthorizer CreateAuthorizer()
        {
            return new BasicUserAuthorizer();
        }
    }
}