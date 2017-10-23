using System.Diagnostics;

namespace FacadePattern
{
    public sealed class DataWarehouseService
    {
        public void RegisterUserRelocation(string userName)
        {
            Debug.WriteLine($"User's relocation was registered in our data-warehouse.");
        }
    }
}