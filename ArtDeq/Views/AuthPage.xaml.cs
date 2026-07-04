namespace ArtDeq.Views;

public partial class AuthPage : ContentPage
{
    public AuthPage()
    {
        InitializeComponent();
    }

    async void OnBackClicked(object? sender, EventArgs e)
    {
        await Shell.Current.Navigation.PopToRootAsync();
    }

    async void OnSignInClicked(object? sender, EventArgs e)
    {
        Preferences.Set("IsLoggedIn", true);
        await Shell.Current.GoToAsync("userprofile");
    }

    async void OnCreateAccountClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("createaccount");
    }

    async void OnContinueBrowsingClicked(object? sender, EventArgs e)
    {
        await Shell.Current.Navigation.PopToRootAsync();
    }
}
