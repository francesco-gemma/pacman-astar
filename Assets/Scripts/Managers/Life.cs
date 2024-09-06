using UnityEngine;
using ScriptableObjectArchitecture;

public class Life : MonoBehaviour {

    public BoolReference levelWon;
    public IntReference lives;

    public void OnPacmanDeath() {
        levelWon.Value = false;
        lives.Value--;
    }
}
