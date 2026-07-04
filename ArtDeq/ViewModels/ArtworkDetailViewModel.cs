using System.Windows.Input;
using ArtDeq.Models;
using ArtDeq.Services.Abstractions;
using ArtDeq.Services.Dummy;
using Microsoft.Extensions.DependencyInjection;

namespace ArtDeq.ViewModels;

[QueryProperty(nameof(ArtworkId), "id")]
public class ArtworkDetailViewModel : BaseViewModel
{
    private readonly ICollectionRepository _collectionRepo;

    public ArtworkDetailViewModel()
    {
        _collectionRepo = IPlatformApplication.Current!.Services
            .GetRequiredService<ICollectionRepository>();

        FlipCommand = new Command(() => IsFlipped = !IsFlipped);
        SaveCommand = new Command(async () => await OnSaveAsync());
        ChatCommand = new Command(async () =>
            await Shell.Current.GoToAsync($"chat?id={Uri.EscapeDataString(ArtworkId)}"));
        CollectCommand = new Command(() => CollectRequested?.Invoke(this, EventArgs.Empty));
    }

    private string _artworkId = string.Empty;
    public string ArtworkId
    {
        get => _artworkId;
        set
        {
            SetProperty(ref _artworkId, value);
            Artwork = DummyData.Artworks.FirstOrDefault(a => a.Id == value);
            _ = RefreshSavedStateAsync();
        }
    }

    private Artwork? _artwork;
    public Artwork? Artwork
    {
        get => _artwork;
        set => SetProperty(ref _artwork, value);
    }

    private bool _isFlipped;
    public bool IsFlipped
    {
        get => _isFlipped;
        set
        {
            if (SetProperty(ref _isFlipped, value))
            {
                OnPropertyChanged(nameof(IsShowingFront));
                OnPropertyChanged(nameof(IsShowingBack));
            }
        }
    }

    public bool IsShowingFront => !IsFlipped;
    public bool IsShowingBack => IsFlipped;

    private bool _isSaved;
    public bool IsSaved
    {
        get => _isSaved;
        set
        {
            if (SetProperty(ref _isSaved, value))
                OnPropertyChanged(nameof(IsNotSaved));
        }
    }
    public bool IsNotSaved => !_isSaved;

    private bool _saveConfirmationVisible;
    public bool SaveConfirmationVisible
    {
        get => _saveConfirmationVisible;
        set => SetProperty(ref _saveConfirmationVisible, value);
    }

    private string _confirmationMessage = string.Empty;
    public string ConfirmationMessage
    {
        get => _confirmationMessage;
        set => SetProperty(ref _confirmationMessage, value);
    }

    public ICommand BackCommand { get; } =
        new Command(async () => await Shell.Current.GoToAsync(".."));

    public ICommand FlipCommand { get; }
    public ICommand SaveCommand { get; }
    public ICommand ChatCommand { get; }
    public ICommand CollectCommand { get; }

    public event EventHandler? CollectRequested;

    private async Task OnSaveAsync()
    {
        if (string.IsNullOrWhiteSpace(ArtworkId)) return;

        if (IsSaved)
        {
            await _collectionRepo.RemoveAsync(ArtworkId);
            IsSaved = false;
            ConfirmationMessage = "Removed from saved artworks.";
            SaveConfirmationVisible = true;
            return;
        }

        await _collectionRepo.SaveAsync(ArtworkId);
        IsSaved = true;
        ConfirmationMessage = "Saved privately. Only you can see this.";
        SaveConfirmationVisible = true;
    }

    private async Task RefreshSavedStateAsync()
    {
        IsSaved = await _collectionRepo.IsSavedAsync(_artworkId);
        SaveConfirmationVisible = false;
    }
}
