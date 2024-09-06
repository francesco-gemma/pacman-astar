using UnityEngine;
using ScriptableObjectArchitecture;

public class GameplayInitializer : MonoBehaviour {

    public LevelParams levelParams;
    public BoolReference newGameToggled;
    public BoolReference levelWon;
    public IntReference level;
    public IntReference lives;
    public IntReference livesDefault;
    public IntReference score;

    public void Setup() {
        Debug.Log("Level setup");
        if(newGameToggled.Value) {
            level.Value = 1;
            lives.Value = livesDefault.Value;
            score.Value = 0;
            newGameToggled.Value = false;
        } else if(levelWon.Value) {
            level.Value++;
            levelWon.Value = false;
        }
        levelParams.UpdateLevelConfiguration(level.Value);
    }

}
