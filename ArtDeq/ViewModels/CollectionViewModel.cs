using System.Collections.ObjectModel;
using System.Windows.Input;
using ArtDeq.Models;
using ArtDeq.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ArtDeq.ViewModels;

public class CollectionViewModel : BaseViewModel
{
    private readonly ICollectionRepository _collectionRepo;

    public ObservableCollection<Artwork> SavedArtworks { get; } = new();

    private bool _hasSavedArtworks;
    public bool HasSavedArtworks
    {
        get => _hasSavedArtworks;
        set
        {
            if (SetProperty(ref _hasSavedArtworks, value))
                OnPropertyChanged(nameof(IsEmpty));
        }
    }

    public bool IsEmpty => !HasSavedArtworks;

    public ICommand BackCommand { get; } =
        new Command(async () => await Shell.Current.GoToAsync(".."));

    public CollectionViewModel()
    {
        _collectionRepo = IPlatformApplication.Current!.Services
            .GetRequiredService<ICollectionRepository>();
    }

    public async Task RefreshAsync()
    {
        var saved = await _collectionRepo.GetSavedAsync();
        SavedArtworks.Clear();
        foreach (var artwork in saved)
            SavedArtworks.Add(artwork);
        HasSavedArtworks = SavedArtworks.Count > 0;
    }
}
