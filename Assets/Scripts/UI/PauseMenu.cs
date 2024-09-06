using UnityEngine.InputSystem;

public class PauseMenu : Menu {

    public void OnKeyPressed(InputAction.CallbackContext value) {
        if(value.action.WasPressedThisFrame()) {
            base.Activate();
        }
    }
}
