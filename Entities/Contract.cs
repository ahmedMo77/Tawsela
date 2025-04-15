using Tawsela.Enums;

namespace Tawsela.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ContractStatus Status { get; set; }

        public int BusinessOwnerId { get; set; }
        public User BusinessOwner { get; set; } = null!;

        public int ShippingCompanyId { get; set; }
        public User ShippingCompany { get; set; } = null!;
    }
}