using ArtDeq.Models;
using ArtDeq.Services.Abstractions;

namespace ArtDeq.Services.Dummy;

public class DummyChatRepository : IChatRepository
{
    public Task<IReadOnlyList<ChatMessage>> GetThreadAsync(string artworkId)
    {
        var now = DateTimeOffset.UtcNow;
        IReadOnlyList<ChatMessage> messages =
        [
            new() { Id = "1", ArtworkId = artworkId, SenderHandle = "me",
                    Text = "Hi! Is this artwork still available?",
                    Timestamp = now.AddMinutes(-50), IsFromMe = true },
            new() { Id = "2", ArtworkId = artworkId, SenderHandle = "creator",
                    Text = "Yes, it is! Happy to answer any questions.",
                    Timestamp = now.AddMinutes(-45), IsFromMe = false },
            new() { Id = "3", ArtworkId = artworkId, SenderHandle = "me",
                    Text = "Is this a limited edition piece?",
                    Timestamp = now.AddMinutes(-30), IsFromMe = true },
            new() { Id = "4", ArtworkId = artworkId, SenderHandle = "creator",
                    Text = "It's 1 of 25 hand-signed prints, each numbered with a certificate of authenticity.",
                    Timestamp = now.AddMinutes(-25), IsFromMe = false },
            new() { Id = "5", ArtworkId = artworkId, SenderHandle = "me",
                    Text = "I'd love to add it to my collection.",
                    Timestamp = now.AddMinutes(-10), IsFromMe = true },
            new() { Id = "6", ArtworkId = artworkId, SenderHandle = "creator",
                    Text = "That means a lot — thank you! I can send you the collection details.",
                    Timestamp = now.AddMinutes(-8), IsFromMe = false },
        ];
        return Task.FromResult(messages);
    }
}
