using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(fileName = "StateManager", menuName = "Scriptable Objects/State Manager")]
public class StateManagerSO : ScriptableObject
{
    public GameStateSO currentState;

    [Header("Broadcasting Events")]
    public GameStateSOGameEvent gameStateChanged;

    private GameStateSO _previousState;

    public void SetGameState(GameStateSO gameState)
    {
        if (this.currentState != null)
            this._previousState = this.currentState;

        this.currentState = gameState;

        if (this.gameStateChanged != null)
            this.gameStateChanged.Raise(gameState);

        Debug.Log("New game state: " + gameState.stateName);
    }

    public void RestorePreviousState()
    {
        this.SetGameState(this._previousState);
    }
}
