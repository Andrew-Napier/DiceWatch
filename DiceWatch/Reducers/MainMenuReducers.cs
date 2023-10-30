using DiceWatch.Actions;
using DiceWatch.FeatureStates;
using DiceWatch.ViewModels;
using Fluxor;

namespace DiceWatch.Reducers;

public static class MainMenuReducers
{
    [ReducerMethod]
    public static MainMenuState ReduceDisplayResultsAction(MainMenuState state, DisplayResultsAction action) =>
        new MainMenuState("Display Results");

    [ReducerMethod]
    public static MainMenuState ReduceResumeRecordingAction(MainMenuState state, ResumeRecordingAction action) =>
        new MainMenuState("Resume Recording");
}