using System.Collections.ObjectModel;
using System.Windows.Input;
using ArtDeq.Models;
using ArtDeq.Services.Dummy;

namespace ArtDeq.ViewModels;

[QueryProperty(nameof(ArtworkId), "id")]
public class ChatViewModel : BaseViewModel
{
    private readonly DummyChatRepository _chatRepo = new();

    private string _artworkId = string.Empty;
    public string ArtworkId
    {
        get => _artworkId;
        set
        {
            SetProperty(ref _artworkId, value);
            Artwork = DummyData.Artworks.FirstOrDefault(a => a.Id == value);
            _ = LoadMessagesAsync();
        }
    }

    private Artwork? _artwork;
    public Artwork? Artwork
    {
        get => _artwork;
        set => SetProperty(ref _artwork, value);
    }

    public ObservableCollection<ChatMessage> Messages { get; } = new();

    private string _messageText = string.Empty;
    public string MessageText
    {
        get => _messageText;
        set => SetProperty(ref _messageText, value);
    }

    public ICommand BackCommand { get; } =
        new Command(async () => await Shell.Current.GoToAsync(".."));

    public ICommand SendCommand { get; }
    public ICommand OpenArtworkCommand { get; }
    public ICommand BuyCommand { get; }

    public event EventHandler? BuyRequested;

    public ChatViewModel()
    {
        SendCommand = new Command(() =>
        {
            if (string.IsNullOrWhiteSpace(MessageText)) return;
            Messages.Add(new ChatMessage
            {
                Id = Guid.NewGuid().ToString(),
                ArtworkId = ArtworkId,
                SenderHandle = "me",
                Text = MessageText.Trim(),
                Timestamp = DateTimeOffset.UtcNow,
                IsFromMe = true
            });
            MessageText = string.Empty;
        });

        OpenArtworkCommand = new Command(async () =>
        {
            if (string.IsNullOrWhiteSpace(ArtworkId)) return;
            await Shell.Current.GoToAsync($"artworkdetail?id={Uri.EscapeDataString(ArtworkId)}");
        });

        BuyCommand = new Command(() => BuyRequested?.Invoke(this, EventArgs.Empty));
    }

    private async Task LoadMessagesAsync()
    {
        Messages.Clear();
        var thread = await _chatRepo.GetThreadAsync(ArtworkId);
        foreach (var msg in thread)
            Messages.Add(msg);
    }
}
