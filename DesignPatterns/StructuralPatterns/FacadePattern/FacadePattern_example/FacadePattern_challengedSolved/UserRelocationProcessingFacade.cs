namespace FacadePattern
{
    public sealed class UserRelocationProcessingFacade(string userName)
    {
        private (string Address, string City) _userAddress;
    
        public bool CanGetAndValidateUserAddress()
        {
            // validate user:
            UserValidationService validationService = new();
            bool isUserValid = validationService.IsUserValid(userName);
            if (!isUserValid)
                return false;

            UserAddressService userAddressService = new();
            _userAddress = userAddressService.GetAddress(userName);

            // confirm user's address
            GovernmentAddressService governmentAddressService = new();
            bool addressCanBeConfirmed = governmentAddressService.CanConfirmAddress(userName, _userAddress);
            if (!addressCanBeConfirmed)
                return false;

            return true;
        }

        public void RegisterRelocation()
        {
            // mark user as moved in primary database
            DataBaseService dataBaseService = new();

            dataBaseService.UpdateUsersAddress(userName, _userAddress);

            // indicate user's move in our data-warehouse
            DataWarehouseService dataWarehouseService = new();

            dataWarehouseService.RegisterUserRelocation(userName);
        }
    }
}