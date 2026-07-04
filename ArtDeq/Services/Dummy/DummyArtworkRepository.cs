using ArtDeq.Models;
using ArtDeq.Services.Abstractions;

namespace ArtDeq.Services.Dummy;

public class DummyArtworkRepository : IArtworkRepository
{
    public Task<IReadOnlyList<Artwork>> GetFeedAsync() =>
        Task.FromResult(DummyData.Artworks);

    public Task<Artwork> GetByIdAsync(string id) =>
        Task.FromResult(DummyData.Artworks.First(a => a.Id == id));
}
