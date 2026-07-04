using Microsoft.Extensions.DependencyInjection;

namespace ArtDeq;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = new Window(new AppShell());

#if WINDOWS
	const double phoneWidth = 400;
	const double phoneHeight = 866;

	window.Width = phoneWidth;
	window.Height = phoneHeight;

	window.MinimumWidth = phoneWidth;
	window.MaximumWidth = phoneWidth;
	window.MinimumHeight = phoneHeight;
	window.MaximumHeight = phoneHeight;
#endif

        return window;
    }
}