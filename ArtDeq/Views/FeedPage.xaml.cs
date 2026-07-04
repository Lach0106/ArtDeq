using ArtDeq.Models;
using ArtDeq.ViewModels;

namespace ArtDeq.Views;

public partial class FeedPage : ContentPage
{
    public FeedPage(FeedViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = ((FeedViewModel)BindingContext).LoadAsync();
    }

    async void OnCardTapped(object? sender, TappedEventArgs e)
    {
        if (e.Parameter is Artwork art)
            await Shell.Current.GoToAsync($"artworkdetail?id={art.Id}");
    }

    async void OnProfileTapped(object? sender, TappedEventArgs e)
    {
        if (Preferences.Get("IsLoggedIn", false))
            await Shell.Current.GoToAsync("userprofile");
        else
            await Shell.Current.GoToAsync("auth");
    }

    async void OnPickPhotoTapped(object? sender, TappedEventArgs e)
    {
        try
        {
            var result = await MediaPicker.Default.PickPhotoAsync();
            if (result is null) return;

            PreviewImage.Source = ImageSource.FromFile(result.FullPath);
            PreviewOverlay.IsVisible = true;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    void OnClosePreviewTapped(object? sender, TappedEventArgs e)
    {
        PreviewOverlay.IsVisible = false;
        PreviewImage.Source = null;
    }

    async void OnCollectionsTapped(object? sender, TappedEventArgs e)
    {
        var message = Uri.EscapeDataString("Browse collections shared by other users.");
        await Shell.Current.GoToAsync($"publiccollections?title=Collections&message={message}");
    }

    async void OnInboxTapped(object? sender, TappedEventArgs e)
    {
        var message = Uri.EscapeDataString("Your creator conversations will appear here.");
        await Shell.Current.GoToAsync($"inbox?title=Inbox&message={message}");
    }

    async void OnSavedTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("collection");
    }
}
