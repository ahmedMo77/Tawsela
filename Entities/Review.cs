namespace Tawsela.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int ReviewerId { get; set; }
        public User Reviewer { get; set; } = null!;

        public int ReviewedUserId { get; set; }
        public User ReviewedUser { get; set; } = null!;
    }
}