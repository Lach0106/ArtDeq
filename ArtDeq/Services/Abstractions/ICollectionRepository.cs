using ArtDeq.Models;

namespace ArtDeq.Services.Abstractions;

public interface ICollectionRepository
{
    Task<IReadOnlyList<Artwork>> GetSavedAsync();
    Task SaveAsync(string artworkId);
    Task RemoveAsync(string artworkId);
    Task<bool> IsSavedAsync(string artworkId);
}
