using System.ComponentModel.DataAnnotations;

namespace tryitter.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        [MaxLength(300)]
        public string? Texto { get; set; }

        [StringLength(300)]
        public string? ImagemUrl { get; set; }

        [Required]
        public int UserId { get; set; }

        public User? User { get; set; }
    }
}