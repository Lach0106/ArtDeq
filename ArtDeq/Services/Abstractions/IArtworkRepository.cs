using ArtDeq.Models;

namespace ArtDeq.Services.Abstractions;

public interface IArtworkRepository
{
    Task<IReadOnlyList<Artwork>> GetFeedAsync();
    Task<Artwork> GetByIdAsync(string id);
}
