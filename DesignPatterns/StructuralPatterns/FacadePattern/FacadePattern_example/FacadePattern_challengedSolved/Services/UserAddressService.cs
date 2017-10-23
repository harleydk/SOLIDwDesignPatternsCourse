namespace FacadePattern
{
    public sealed class UserAddressService
    {
        public (string Address, string City) GetAddress(string userName)
        {
            return (Address: "Foo address", City: "Bar city");
        }
    }
}