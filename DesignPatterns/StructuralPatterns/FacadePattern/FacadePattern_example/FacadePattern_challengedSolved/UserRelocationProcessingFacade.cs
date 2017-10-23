namespace FacadePattern
{
    public sealed class UserRelocationProcessingFacade
    {
        private string _userName;
        private (string Address, string City) _userAddress;

        public UserRelocationProcessingFacade(string userName)
        {
            _userName = userName;
        }

        public bool CanGetAndValidateUserAddress()
        {
            // validate user:
            UserValidationService validationService = new UserValidationService();
            bool isUserValid = validationService.IsUserValid(_userName);
            if (!isUserValid)
                return false;

            UserAddressService userAddressService = new UserAddressService();
            _userAddress = userAddressService.GetAddress(_userName);

            // confirm user's address
            GovernmentAddressService governmentAddressService = new GovernmentAddressService();
            bool addressCanBeConfirmed = governmentAddressService.CanConfirmAddress(_userName, _userAddress);
            if (!addressCanBeConfirmed)
                return false;

            return true;
        }

        public void RegisterRelocation()
        {
            // mark user as moved in primary database
            DataBaseService dataBaseService = new DataBaseService();

            dataBaseService.UpdateUsersAddress(_userName, _userAddress);

            // indicate user's move in our data-warehouse
            DataWarehouseService dataWarehouseService = new DataWarehouseService();

            dataWarehouseService.RegisterUserRelocation(_userName);
        }
    }
}