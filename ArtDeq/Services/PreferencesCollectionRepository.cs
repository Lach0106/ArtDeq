using System.Text.Json;
using ArtDeq.Models;
using ArtDeq.Services.Abstractions;

namespace ArtDeq.Services;

public class PreferencesCollectionRepository : ICollectionRepository
{
    private const string PrefsKey = "saved_artwork_ids";
    private readonly IArtworkRepository _artworkRepo;

    public PreferencesCollectionRepository(IArtworkRepository artworkRepo)
    {
        _artworkRepo = artworkRepo;
    }

    private List<string> LoadIds()
    {
        var json = Preferences.Get(PrefsKey, "[]");
        return JsonSerializer.Deserialize<List<string>>(json) ?? [];
    }

    private void PersistIds(List<string> ids) =>
        Preferences.Set(PrefsKey, JsonSerializer.Serialize(ids));

    public async Task<IReadOnlyList<Artwork>> GetSavedAsync()
    {
        var ids = LoadIds();
        var result = new List<Artwork>();
        foreach (var id in ids)
        {
            try { result.Add(await _artworkRepo.GetByIdAsync(id)); }
            catch { }
        }
        return result;
    }

    public Task SaveAsync(string artworkId)
    {
        var ids = LoadIds();
        if (!ids.Contains(artworkId))
        {
            ids.Add(artworkId);
            PersistIds(ids);
        }
        return Task.CompletedTask;
    }

    public Task RemoveAsync(string artworkId)
    {
        var ids = LoadIds();
        if (ids.Remove(artworkId)) PersistIds(ids);
        return Task.CompletedTask;
    }

    public Task<bool> IsSavedAsync(string artworkId) =>
        Task.FromResult(LoadIds().Contains(artworkId));
}
