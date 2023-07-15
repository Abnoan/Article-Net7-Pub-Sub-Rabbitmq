namespace PowerShop.Sales.Models
{
    public class CustomerCreatedEvent
    {
        public CustomerCreatedEvent(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
    }
}
