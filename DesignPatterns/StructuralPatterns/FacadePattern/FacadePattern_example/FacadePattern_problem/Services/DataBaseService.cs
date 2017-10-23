using System.Diagnostics;

namespace FacadePattern_problem
{
    public sealed class DataBaseService
    {
        public void UpdateUsersAddress(string userName, (string Address, string City) userAddress)
        {
            Debug.WriteLine($"User '{userName}' address was updated.");
        }
    }
}