namespace AbstractFactoryPattern
{
    public sealed class SuperUserSecurityProviderFactory : ISecurityProviderFactory
    {
        public IAuthenticator CreateAuthenticator()
        {
            return new SuperUserAuthenticator(); // note, we could - should? - derive these from the use of DI.
        }

        public IAuthorizer CreateAuthorizer()
        {
            return new SuperUserAuthorizer();
        }
    }
}