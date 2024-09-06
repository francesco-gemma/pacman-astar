using UnityEngine;
using UnityEngine.InputSystem;
using ScriptableObjectArchitecture;

public class PlayerController : MonoBehaviour {

    public GameEvent onLevelEnded;
    
    private Movement movement;
    private Vector2 _movementInput;


    private void Awake() {
        movement = GetComponent<Movement>();
    }

    private void FixedUpdate() {
        movement.SetDirection(_movementInput);
        this.GetComponent<SpriteRotation>().Rotate(movement.direction);
    }

    public void OnMovement(InputAction.CallbackContext value) {
        if(value.ReadValue<Vector2>() != Vector2.zero)
            _movementInput = value.ReadValue<Vector2>();
    }

    public void OnPacmanDeathAnimationEnded() {
        onLevelEnded.Raise();
    }

}