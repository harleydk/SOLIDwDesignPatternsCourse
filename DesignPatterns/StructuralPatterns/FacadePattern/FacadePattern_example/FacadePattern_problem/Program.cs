namespace FacadePattern_problem
{
    public static class Program
    {
        /// <summary>
        /// A user relocates from one city to another. We need to process this move. This includes calls to numerous external subsystems. This is somewhat messy to look at, and thus our maintainability potential might suffer. By hiding the complexity behind a facade, we gain a lot.
        /// </summary>
        public static void Main()
        {
            var user = new { Name = "Clint" };

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

            // Lab - introduce a facade-class, that introduces a simpler interface in regards to the above service-calls.
        }
    }
}