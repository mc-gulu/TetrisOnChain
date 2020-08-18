using UnityEngine;
using UnityEditor;
using MMFramework;

// ensure class initializer is called whenever scripts recompile
[InitializeOnLoadAttribute]
public static class PauseStateChangedExample
{
    // register an event handler when the class is initialized
    static PauseStateChangedExample()
    {
        EditorApplication.pauseStateChanged += LogPauseState;
    }

    private static void LogPauseState(PauseState state)
    {
        Debug.Log(state);
        RootModule.Instance.PauseAll(state == PauseState.Paused);
    }
}