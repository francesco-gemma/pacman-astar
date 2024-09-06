using UnityEngine;
using System.Collections.Generic;

public class SpeedChanger : MonoBehaviour {

    [SerializeField]
    protected LevelParams levelParams;

    public float speedDefault;

    private float currentMultiplier;

    private float previousMultiplier;

    private void Awake() {
        currentMultiplier = Default();
        previousMultiplier = Default();
    }
    public float ChangeSpeed(float multiplier) {
        if(multiplier != currentMultiplier) {
            this.previousMultiplier = this.currentMultiplier;
            this.currentMultiplier = multiplier;
        }
        return speedDefault * currentMultiplier;
    }
    public float PreviousSpeed() {
        return ChangeSpeed(this.previousMultiplier);
    }

    protected virtual float Default() {
        return ChangeSpeed(1.0f);
    }

}
