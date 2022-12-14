using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tryitter.Models
{
    public class TryitterPost
    {
        [Key]
        public int TryitterPostId { get; set; }

        [Required]
        [MaxLength(300)]
        public string? Texto { get; set; }

        [StringLength(300)]
        public string? ImagemUrl { get; set; }

        [Required]
        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
    }
}