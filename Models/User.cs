using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tryitter.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        [StringLength(100)]
        public string? Senha { get; set; }

        [StringLength(80)]
        public string? Modulo { get; set; }

        [StringLength(300)]
        public string? Status { get; set; }

        [JsonIgnore]
        public ICollection<TryitterPost>? TryitterPosts { get; set; }
    }
}