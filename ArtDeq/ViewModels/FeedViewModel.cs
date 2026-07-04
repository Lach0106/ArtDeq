using System.Collections.ObjectModel;
using ArtDeq.Models;
using ArtDeq.Services.Abstractions;

namespace ArtDeq.ViewModels;

public class FeedViewModel : BaseViewModel
{
    private readonly IArtworkRepository _repo;

    public ObservableCollection<Artwork> LeftArtworks { get; } = [];
    public ObservableCollection<Artwork> RightArtworks { get; } = [];

    public FeedViewModel(IArtworkRepository repo) => _repo = repo;

    public async Task LoadAsync()
    {
        var items = await _repo.GetFeedAsync();
        LeftArtworks.Clear();
        RightArtworks.Clear();
        for (int i = 0; i < items.Count; i++)
        {
            if (i % 2 == 0) LeftArtworks.Add(items[i]);
            else RightArtworks.Add(items[i]);
        }
    }
}
