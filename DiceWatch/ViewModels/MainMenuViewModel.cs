using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiceWatch.Actions;
using DiceWatch.FeatureStates;
using DiceWatch.Views;
using Fluxor;
using static Microsoft.Maui.Controls.Shell;
using IDispatcher = Fluxor.IDispatcher;

namespace DiceWatch.ViewModels;

// ViewModels should descend from the CommunityToolKit ObservableObject.
// By doing this, we trivialise the wire-up of two-way property linking
// to the bound view.
public partial class MainMenuViewModel : ObservableObject
{
    private IDispatcher _dispatcher;
    private IState<MainMenuState> _mainMenuState;

    // By marking a private property with the ObservableProperty attribute
    // we get code generated to have a bound property which can be referenced
    // by the view.  I haven't pushed the convention naming scheme, but I know
    // that private "_lastPressed" maps to public "LastPressed". 
    [ObservableProperty] private string _lastPressed;

    public MainMenuViewModel(IState<MainMenuState> mainMenuState, IDispatcher dispatcher)
    {
        _mainMenuState = mainMenuState;

        // Wire up an event handler that reacts to a new version of the MainMenuState object.
        _mainMenuState.StateChanged += _mainMenuState_StateChanged;
        _dispatcher = dispatcher;
    }

    private void _mainMenuState_StateChanged(object sender, EventArgs e)
    {
        // Update the bound-control with the details of the state-object.
        LastPressed = _mainMenuState.Value.LastActioned;
    }

    // Similar shortcut shenanigans... The RelayCommand attribute gives you a convention named
    // Command property that can be referenced in your view.  This method can be referenced from
    // the view by {Binding StartRecordingCommand}
    [RelayCommand]
    async Task StartRecording()
    {
        await Current.GoToAsync(nameof(RecordingPage));
    }

    // The RelayCommand also allows you to call void synchronous methods.
    [RelayCommand]
    void ResumeRecording()
    {
        _dispatcher.Dispatch(new ResumeRecordingAction());
    }

    [RelayCommand]
    void DisplayResults()
    {
        _dispatcher.Dispatch(new DisplayResultsAction());
    }
}