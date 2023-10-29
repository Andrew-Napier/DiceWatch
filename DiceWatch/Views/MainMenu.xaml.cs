using DiceWatch.ViewModels;

namespace DiceWatch
{
    public partial class MainMenu : ContentPage
    {
        public MainMenu(MainMenuViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}