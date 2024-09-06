using UnityEngine;
using UnityEngine.InputSystem;

class PlayerInputHandler : MonoBehaviour {
    PlayerInput input;
    bool isPaused;

    void Start() {
        input = GetComponent<PlayerInput>();
    }

    void OnPause() {
        isPaused = !isPaused;
        if(isPaused) {
            input.SwitchCurrentActionMap("UI");
        } else {
            input.SwitchCurrentActionMap("Player");
        }
    }
}