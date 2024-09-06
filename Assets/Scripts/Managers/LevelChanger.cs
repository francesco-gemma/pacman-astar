using UnityEngine;
using ScriptableObjectArchitecture;

public class LevelChanger : MonoBehaviour {
    public BoolReference levelWon;
    public IntReference level;

    public void IncreaseLevel() {
        if(levelWon.Value) {
            level.Value++;
            levelWon.Value = false;
        }
    }
}
