using ArtDeq.ViewModels;

namespace ArtDeq.Views;

public partial class ArtworkDetailPage : ContentPage
{
    public ArtworkDetailPage()
    {
        InitializeComponent();
        BindingContext = new ArtworkDetailViewModel();

        if (BindingContext is ArtworkDetailViewModel vm)
            vm.CollectRequested += OnCollectRequested;
    }

    async void OnCollectRequested(object? sender, EventArgs e) =>
        await DisplayAlert("Buy Artwork",
            "External purchase link will be available in the next iteration.",
            "OK");
}
