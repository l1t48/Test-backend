namespace MyBackend.Dtos
{
    public class QuoteUpdateDto
    {
        public string Text { get; set; } = null!;
        public string? Author { get; set; }
    }
}