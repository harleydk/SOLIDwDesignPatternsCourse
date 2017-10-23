namespace AdapterPattern
{
    public class ThirdPartyAuthenticator : IThirdPartyAuthenticator
    {
        private string name;
        private string password;

        public void StoreCredentials(string _name, string _password)
        {
            name = _name;
            password = _password;
        }

        public bool TryToAuthenciate()
        {
            return (name == "Clint Eastwood" && password == "MakeMyDayPunk" ? true : false);
        }
    }
}