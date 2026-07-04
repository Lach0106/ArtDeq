using ArtDeq.Models;

namespace ArtDeq.Services.Abstractions;

public interface IChatRepository
{
    Task<IReadOnlyList<ChatMessage>> GetThreadAsync(string artworkId);
}
