namespace ArtDeq.Views;

public partial class CreateAccountPage : ContentPage
{
    public CreateAccountPage()
    {
        InitializeComponent();
        RolePicker.SelectedIndex = 0;
    }

    async void OnBackClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    async void OnCreateAccountClicked(object? sender, EventArgs e)
    {
        var name = DisplayNameEntry.Text?.Trim();
        var username = UsernameEntry.Text?.Trim();
        var role = RolePicker.SelectedItem?.ToString() ?? "Creator";

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username))
        {
            await DisplayAlertAsync("Required", "Please enter a display name and username.", "OK");
            return;
        }

        Preferences.Set("DisplayName", name);
        Preferences.Set("Username", username);
        Preferences.Set("UserRole", role);
        Preferences.Set("IsLoggedIn", true);

        await Shell.Current.GoToAsync("userprofile");
    }
}
