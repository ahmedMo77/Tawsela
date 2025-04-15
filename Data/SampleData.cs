using Tawsela.Entities;
using Tawsela.Enums;

namespace Tawsela.Data
{
    public static class SampleData
    {
        public static async Task InitializeAsync(AppDbContext context)
        {
            if (context.Users.Any()) return;

            // Seed Users
            var users = new List<User>
            {
                new User { FullName = "Ahmed Khaled", Email = "ahmed@example.com", PasswordHash = HashPassword("owner123"), Role = UserRole.BusinessOwner },
                new User { FullName = "Sara Ali", Email = "sara@example.com", PasswordHash = HashPassword("user123"), Role = UserRole.SingleUser },
                new User { FullName = "Omar Tarek", Email = "omar@example.com", PasswordHash = HashPassword("courier123"), Role = UserRole.DeliveryPerson },
                new User { FullName = "Express Co.", Email = "express@example.com", PasswordHash = HashPassword("shipco123"), Role = UserRole.ShippingCompany },
                new User { FullName = "Admin User", Email = "admin@example.com", PasswordHash = HashPassword("admin123"), Role = UserRole.Admin }
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync(); // Ensure IDs are generated

            // Get references to users for relationships
            var businessOwner = users.First(u => u.Role == UserRole.BusinessOwner);
            var singleUser = users.First(u => u.Role == UserRole.SingleUser);
            var deliveryPerson = users.First(u => u.Role == UserRole.DeliveryPerson);
            var shippingCompany = users.First(u => u.Role == UserRole.ShippingCompany);

            // Seed Shipments
            var shipments = new List<Shipment>
            {
                new Shipment
                {
                    Description = "Documents Delivery",
                    PickupAddress = "Cairo, Downtown",
                    DeliveryAddress = "Alexandria, Station",
                    CreatedAt = DateTime.UtcNow,
                    Status = ShipmentStatus.Pending,
                    SenderId = singleUser.Id,
                    CourierId = deliveryPerson.Id
                },
                new Shipment
                {
                    Description = "Package to Giza",
                    PickupAddress = "Mansoura, University St.",
                    DeliveryAddress = "Giza, Haram",
                    CreatedAt = DateTime.UtcNow,
                    Status = ShipmentStatus.InTransit,
                    SenderId = singleUser.Id,
                    CourierId = shippingCompany.Id // Handled by a company in this case
                }
            };

            // Seed Contracts
            var contracts = new List<Contract>
            {
                new Contract
                {
                    Title = "Monthly Delivery Contract",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(1),
                    Status = ContractStatus.Accepted,
                    BusinessOwnerId = businessOwner.Id,
                    ShippingCompanyId = shippingCompany.Id
                },
                new Contract
                {
                    Title = "3-Month Agreement",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(3),
                    Status = ContractStatus.Pending,
                    BusinessOwnerId = businessOwner.Id,
                    ShippingCompanyId = shippingCompany.Id
                }
            };

            // Seed Reviews
            var reviews = new List<Review>
            {
                new Review
                {
                    Rating = 5,
                    Comment = "Very fast and reliable delivery!",
                    CreatedAt = DateTime.UtcNow,
                    ReviewerId = singleUser.Id,
                    ReviewedUserId = deliveryPerson.Id
                },
                new Review
                {
                    Rating = 4,
                    Comment = "Good service from shipping company",
                    CreatedAt = DateTime.UtcNow,
                    ReviewerId = businessOwner.Id,
                    ReviewedUserId = shippingCompany.Id
                }
            };

            await context.Shipments.AddRangeAsync(shipments);
            await context.Contracts.AddRangeAsync(contracts);
            await context.Reviews.AddRangeAsync(reviews);

            await context.SaveChangesAsync();
            Console.WriteLine("✅ Sample data seeded successfully.");
        }

        // Simple fake hash method (just for demo seeding)
        private static string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
