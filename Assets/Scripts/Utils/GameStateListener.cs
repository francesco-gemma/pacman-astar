using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.Events;
using System.Collections.Generic;

public class GameStateListener : MonoBehaviour
{
    [Header("Listening to Events")]
    public GameStateSOGameEvent gameStateChangedEvent;

    [Header("Enabled & Disabled Shortcuts")]
    public MonoBehaviour[] components;
    public List<GameStateSO> enabledStates;
    public List<GameStateSO> disabledStates;

    [Header("Actions")]
    public UnityEvent onLoadingGameplayState;
    public UnityEvent onPlayingState;
    public UnityEvent onPauseState;
    public UnityEvent onLoadingSceneState;

    private void OnEnable()
    {
        this.gameStateChangedEvent.AddListener(GameStateChanged);
    }

    private void OnDisable()
    {
        this.gameStateChangedEvent.RemoveListener(GameStateChanged);
    }

    private void GameStateChanged(GameStateSO newGameState)
    {
        InvokeShortcuts(newGameState);
        InvokeActions(newGameState);
    }

    private void InvokeShortcuts(GameStateSO newGameState)
    {
        foreach (var component in this.components)
        {
            if (this.enabledStates.Contains(newGameState))
            {
                component.enabled = true;
            }

            if (this.disabledStates.Contains(newGameState))
            {
                component.enabled = false;
            }
        }
    }

    private void InvokeActions(GameStateSO newGameState)
    {
        if (newGameState.stateName == "LoadingGameplay" && this.onLoadingGameplayState != null)
            this.onLoadingGameplayState.Invoke();

        if (newGameState.stateName == "Playing" && this.onPlayingState != null)
            this.onPlayingState.Invoke();

        if (newGameState.stateName == "Paused" && this.onPauseState != null)
            this.onPauseState.Invoke();

        if (newGameState.stateName == "LoadingScene" && this.onLoadingSceneState != null)
            this.onLoadingSceneState.Invoke();

    }
}
