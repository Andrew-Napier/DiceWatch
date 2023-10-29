using Fluxor;

namespace DiceWatch
{
    // According to phind.com:
    // App serves as the main application class where you can set properties that are available to
    // the entire application.  
    public partial class App : Application
    {
        private IStore _store;

        public App(IStore store)
        {
            InitializeComponent();

            _store = store;
            _store.InitializeAsync().Wait();
            MainPage = new AppShell();
        }
    }
}