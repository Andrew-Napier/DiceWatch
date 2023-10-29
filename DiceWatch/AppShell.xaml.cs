using DiceWatch.Views;

namespace DiceWatch;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(RecordingPage), typeof(RecordingPage));
    }
}