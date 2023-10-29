using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluxor;

namespace DiceWatch.FeatureStates
{
    /// <summary>
    /// Simple example of a state, used by the main-menu and currently demonstrating
    /// how a button press travels through the system.
    /// </summary>
    // A state is dispatched via the GUI, to indicate a change is required.
    // States should be immutable, and prefixed with the FeatureState attribute
    [FeatureState]
    public class MainMenuState
    {
        public string LastActioned { get; private set; } = String.Empty;

        public MainMenuState()
        {
            // States should have a parameterless constructor, but I 
            // can't remember why!
        }

        public MainMenuState(string lastActioned)
        {
            // As it's an immutable class, we also need a constructor that will set the 
            // properties of the object as happens here.
            LastActioned = lastActioned;
        }
    }
}