using ArtDeq.ViewModels;

namespace ArtDeq.Views;

public partial class ChatPage : ContentPage
{
    public ChatPage()
    {
        InitializeComponent();
        BindingContext = new ChatViewModel();

        if (BindingContext is ChatViewModel vm)
            vm.BuyRequested += OnBuyRequested;
    }

    async void OnBuyRequested(object? sender, EventArgs e) =>
        await DisplayAlert("Buy Artwork",
            "External purchase link will be available in the next iteration.",
            "OK");
}
