namespace ArtDeq.Views;

[QueryProperty(nameof(Title), "title")]
[QueryProperty(nameof(PlaceholderMessage), "message")]
public partial class PlaceholderPage : ContentPage
{
    public PlaceholderPage()
    {
        InitializeComponent();
    }

    public string PlaceholderMessage
    {
        set => MessageLabel.Text = value;
    }

    async void OnBackClicked(object? sender, EventArgs e) =>
        await Shell.Current.GoToAsync("..");

    protected override void OnPropertyChanged(string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == nameof(Title) && !string.IsNullOrEmpty(Title))
            HeadingLabel.Text = Title;
    }
}
