namespace FactoryPattern
{
    public interface ISecurityProviderFactory
    {
        IAuthenticator CreateAuthenticator();

        IAuthorizer CreateAuthorizer();
    }
}