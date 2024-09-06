using UnityEngine;

public class GameStateChanger : MonoBehaviour
{
    [Header("Dependencies")]
    public StateManagerSO stateManager;

    public void SetGameState(GameStateSO gameState)
    {
        this.stateManager.SetGameState(gameState);
    }

    public void RestorePreviousState()
    {
        this.stateManager.RestorePreviousState();
    }
}
