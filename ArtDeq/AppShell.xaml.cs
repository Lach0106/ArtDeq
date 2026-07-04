namespace ArtDeq;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("artworkdetail", typeof(Views.ArtworkDetailPage));
        Routing.RegisterRoute("chat", typeof(Views.ChatPage));
        Routing.RegisterRoute("auth", typeof(Views.AuthPage));
        Routing.RegisterRoute("createaccount", typeof(Views.CreateAccountPage));
        Routing.RegisterRoute("userprofile", typeof(Views.ProfilePage));
        Routing.RegisterRoute("collection", typeof(Views.CollectionPage));
        Routing.RegisterRoute("publiccollections", typeof(Views.PlaceholderPage));
        Routing.RegisterRoute("inbox", typeof(Views.PlaceholderPage));
    }
}
