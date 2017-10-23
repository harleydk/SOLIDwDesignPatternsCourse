namespace AdapterPattern
{
    public interface IThirdPartyAuthenticator
    {
        void StoreCredentials(string _name, string _password);

        bool TryToAuthenciate();
    }
}