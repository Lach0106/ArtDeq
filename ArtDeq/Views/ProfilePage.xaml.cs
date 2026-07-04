namespace ArtDeq.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var name = Preferences.Get("DisplayName", "Artist");
        var username = Preferences.Get("Username", "user");
        var role = Preferences.Get("UserRole", "Creator");

        DisplayNameLabel.Text = name;
        UsernameLabel.Text = username.StartsWith('@') ? username : $"@{username}";
        RoleLabel.Text = role;
    }

    async void OnBackClicked(object? sender, EventArgs e)
    {
        await Shell.Current.Navigation.PopToRootAsync();
    }

    async void OnLogOutClicked(object? sender, EventArgs e)
    {
        Preferences.Set("IsLoggedIn", false);
        await Shell.Current.GoToAsync("auth");
    }
}
