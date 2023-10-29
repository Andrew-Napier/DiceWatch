using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiceWatch.Views;
using static Microsoft.Maui.Controls.Shell;

namespace DiceWatch.ViewModels;

public partial class MainMenuViewModel : ObservableObject
{
    [ObservableProperty] private string _lastPressed;

    [RelayCommand]
    async Task StartRecording()
    {
        await Current.GoToAsync(nameof(RecordingPage));
    }

    [RelayCommand]
    async Task ResumeRecording()
    {
        LastPressed = "resume";
    }

    [RelayCommand]
    async Task DisplayResults()
    {
        LastPressed = "display";
    }
}