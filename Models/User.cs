namespace tryitter.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public string? Modulo { get; set; }

        public string? Status { get; set; }

        public ICollection<Post>? Posts { get; set; }
    }
}