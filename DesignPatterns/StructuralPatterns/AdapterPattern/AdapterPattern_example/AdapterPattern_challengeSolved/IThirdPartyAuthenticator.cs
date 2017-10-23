namespace AdapterPattern
{
    public interface IThirdPartyAuthenticator
    {
        void StoreCredentials(string name, string password);

        bool TryToAuthenciate();
    }
}