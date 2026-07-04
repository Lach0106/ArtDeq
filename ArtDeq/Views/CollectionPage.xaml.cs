using ArtDeq.Models;
using ArtDeq.ViewModels;

namespace ArtDeq.Views;

public partial class CollectionPage : ContentPage
{
    public CollectionPage()
    {
        InitializeComponent();
        BindingContext = new CollectionViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = ((CollectionViewModel)BindingContext).RefreshAsync();
    }

    async void OnArtworkTapped(object? sender, TappedEventArgs e)
    {
        if (e.Parameter is Artwork art)
            await Shell.Current.GoToAsync($"artworkdetail?id={Uri.EscapeDataString(art.Id)}");
    }
}
