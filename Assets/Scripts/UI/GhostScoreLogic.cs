using UnityEngine;
using ScriptableObjectArchitecture;

public class GhostScoreLogic : MonoBehaviour {

    public IntReference ghostScoreDefault;

    public IntReference ghostScore;

    private int numGhostEaten;

    private void Awake() {
        Reset();
    }

    public void Reset() {
        this.ghostScore.Value = this.ghostScoreDefault.Value;
        numGhostEaten = 0;
    }

    public void UpdateScore() {
        // Integer power of 2
        this.ghostScore.Value = this.ghostScoreDefault.Value * (1 << numGhostEaten);
        numGhostEaten++;
    }
}