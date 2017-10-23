namespace FacadePattern
{
    public sealed class UserValidationService
    {
        public bool IsUserValid(string userName)
        {
            bool isUserValid = userName == "Clint";
            return isUserValid;
        }
    }
}