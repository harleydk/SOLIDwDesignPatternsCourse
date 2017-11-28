namespace AbstractFactoryPattern
{
    public interface ISecurityProviderFactory
    {
        IAuthenticator CreateAuthenticator();

        IAuthorizer CreateAuthorizer();
    }
}