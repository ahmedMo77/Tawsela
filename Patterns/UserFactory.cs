using Tawsela.Entities;
using Tawsela.Enums;

namespace Tawsela.Patterns
{
    // factory pattern
    public static class UserFactory
    {
        public static User CreateUser(UserRole role, string fullName, string email, string passwordHash)
        {
            User user = role switch
            {
                UserRole.BusinessOwner => new BusinessOwnerUser(),
                UserRole.DeliveryPerson => new DeliveryPersonUser(),
                UserRole.ShippingCompany => new ShippingCompanyUser(),
                UserRole.SingleUser => new SingleUser(),
                _ => throw new ArgumentException("Invalid role")
            };

            user.FullName = fullName;
            user.Email = email;
            user.PasswordHash = passwordHash;

            return user;
        }
    }
}
