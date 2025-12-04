namespace MyBackend.Dtos
{
    public class QuoteCreateDto
    {
        public string Text { get; set; } = null!;
        public string? Author { get; set; }
    }
}
