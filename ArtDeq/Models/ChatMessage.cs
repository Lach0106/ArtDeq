namespace ArtDeq.Models;

public class ChatMessage
{
    public string Id { get; set; } = string.Empty;
    public string ArtworkId { get; set; } = string.Empty;
    public string SenderHandle { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateTimeOffset Timestamp { get; set; }
    public bool IsFromMe { get; set; }
}
