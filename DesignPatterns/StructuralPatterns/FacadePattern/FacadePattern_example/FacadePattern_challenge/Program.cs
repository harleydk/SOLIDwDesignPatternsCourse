namespace FacadePattern
{
    public static class Program
    {
        public static void Main()
        {
            var user = new { Name = "Clint" };

            // Lab - implement a facade-class, that introduces a simpler interface in regards to the below service-calls.

            /*#
            // validate user:
            UserValidationService validationService = new UserValidationService();
            bool isUserValid = validationService.IsUserValid(user.Name);
            if (!isUserValid)
                return;

            UserAddressService userAddressService = new UserAddressService();
            var userAddress = userAddressService.GetAddress(user.Name);

            // confirm user's address
            GovernmentAddressService governmentAddressService = new GovernmentAddressService();
            bool addressCanBeConfirmed = governmentAddressService.CanConfirmAddress(user.Name, userAddress);
            if (!addressCanBeConfirmed)
                return;

            // mark user as moved in primary database
            DataBaseService dataBaseService = new DataBaseService();
            dataBaseService.UpdateUsersAddress(user.Name, userAddress);

            // indicate user's move in our data-warehouse
            DataWarehouseService dataWarehouseService = new DataWarehouseService();
            dataWarehouseService.RegisterUserRelocation(user.Name);

           */
        }
    }
}