using Tawsela.Enums;

namespace Tawsela.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public UserRole Role { get; set; }

        // Navigation Properties
        public ICollection<Shipment>? Shipments { get; set; }
        public ICollection<Contract>? Contracts { get; set; }
        public ICollection<Review>? ReviewsWritten { get; set; }
    }

    public class BusinessOwnerUser : User
    {
        public BusinessOwnerUser()
        {
            Role = UserRole.BusinessOwner;
        }

        //  business owner logic
    }

    public class DeliveryPersonUser : User
    {
        public DeliveryPersonUser()
        {
            Role = UserRole.DeliveryPerson;
        }

        // delivery person logic
    }

    public class ShippingCompanyUser : User
    {
        public ShippingCompanyUser()
        {
            Role = UserRole.ShippingCompany;
        }

        // shipping company logic
    }

    public class SingleUser : User
    {
        public SingleUser()
        {
            Role = UserRole.SingleUser;
        }

        // single user logic
    }
}
