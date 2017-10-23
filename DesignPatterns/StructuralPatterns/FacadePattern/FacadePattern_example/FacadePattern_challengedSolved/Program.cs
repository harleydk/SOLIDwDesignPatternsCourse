namespace FacadePattern
{
    public static class Program
    {
        /// <summary>
        /// By introducing a facade-class to handle the numerous underlying service-calls, we've effectively abstracted much of the plumbing-details away.
        /// </summary>
        public static void Main()
        {
            var user = new { Name = "Clint" };

            UserRelocationProcessingFacade userRelocationProcessingFacade = new UserRelocationProcessingFacade(user.Name);

            bool canGetAndValidateUserAddress = userRelocationProcessingFacade.CanGetAndValidateUserAddress();

            if (canGetAndValidateUserAddress)
                userRelocationProcessingFacade.RegisterRelocation();
        }
    }
}