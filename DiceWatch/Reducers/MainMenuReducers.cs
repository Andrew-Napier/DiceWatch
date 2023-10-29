using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceWatch.Actions;
using DiceWatch.FeatureStates;
using Fluxor;

namespace DiceWatch.Reducers;

public static class MainMenuReducers
{
    [ReducerMethod]
    public static MainMenuState ReduceDisplayResultsAction(MainMenuState state, DisplayResultsAction action) =>
        new MainMenuState("Display Results");

    [ReducerMethod]
    public static MainMenuState ReduceResumeRecordingAction(MainMenuState state, DisplayResultsAction action) =>
        new MainMenuState("Resume Recording");
}