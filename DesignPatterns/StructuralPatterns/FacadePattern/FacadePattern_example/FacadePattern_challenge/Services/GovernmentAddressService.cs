namespace FacadePattern
{
    public sealed class GovernmentAddressService
    {
        public bool CanConfirmAddress(string userName, (string Address, string City) address)
        {
            bool canConfirmAddress =
                userName == "Clint" &&
                address.Address == "Foo address" &&
                address.City == "Bar city";

            return canConfirmAddress;
        }
    }
}