using Tawsela.Entities;
using Tawsela.Enums;
using System.Collections.Generic;

namespace Tawsela
{
    public class SampleData
    {
        // 1. Explicitly declare the type (don't use 'var' here)
        public List<User> Users = new List<User>
        {
            new User { Id = 1, FullName = "Ahmed Hassan", Email = "ahmed@example.com", PasswordHash = "hashed1", Role = UserRole.BusinessOwner },
            new User { Id = 2, FullName = "Sara Ali", Email = "sara@example.com", PasswordHash = "hashed2", Role = UserRole.ShippingCompany },
            new User { Id = 3, FullName = "Omar Youssef", Email = "omar@example.com", PasswordHash = "hashed3", Role = UserRole.SingleUser },
            new User { Id = 4, FullName = "Laila Tarek", Email = "laila@example.com", PasswordHash = "hashed4", Role = UserRole.DeliveryPerson }
        };

        public List<Shipment> Shipments = new List<Shipment>
        {
            new Shipment
            {
                Id = 1,
                Description = "Laptop Delivery",
                PickupAddress = "Mansoura, Street 5",
                DeliveryAddress = "Cairo, Nasr City",
                CreatedAt = DateTime.UtcNow.AddDays(-2),
                Status = ShipmentStatus.InTransit,
                SenderId = 3,
                CourierId = 4
            },
            new Shipment
            {
                Id = 2,
                Description = "Documents Delivery",
                PickupAddress = "Alexandria, Station St.",
                DeliveryAddress = "Tanta, Center 3",
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                Status = ShipmentStatus.Delivered,
                SenderId = 1,
                CourierId = 2
            }
        };

        public List<Contract> Contracts = new List<Contract>
        {
            new Contract
            {
                Id = 1,
                Title = "Monthly Delivery Contract",
                StartDate = DateTime.UtcNow.AddDays(-30),
                EndDate = DateTime.UtcNow.AddDays(30),
                Status = ContractStatus.Accepted,
                BusinessOwnerId = 1,
                ShippingCompanyId = 2
            }
        };

        public List<Review> Reviews = new List<Review>
        {
            new Review
            {
                Id = 1,
                Rating = 5,
                Comment = "Excellent delivery service!",
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                ReviewerId = 1,       // Ahmed (BusinessOwner)
                ReviewedUserId = 2    // Sara (Shipping Company)
            },
            new Review
            {
                Id = 2,
                Rating = 4,
                Comment = "Fast but could improve communication.",
                CreatedAt = DateTime.UtcNow,
                ReviewerId = 3,       // Omar (SingleUser)
                ReviewedUserId = 4    // Laila (Delivery Person)
            }
        };
    }
}
