namespace tryitter.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public string? Texto { get; set; }

        public string? ImagemUrl { get; set; }

        public int UserId { get; set; }
    }
}