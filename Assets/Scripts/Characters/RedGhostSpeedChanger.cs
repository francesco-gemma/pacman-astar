using ScriptableObjectArchitecture;
public class RedGhostSpeedChanger : GhostSpeedChanger {

    public IntReference numPelletsEaten;
    public IntReference totPellets;

    public void OnPelletEaten() {
        if(this.GetComponent<Ghost>().state == GhostStates.CHASE) {
            base.aiLerp.speed = Default();
        }
    }
    protected override float Default() {
        int toBeEaten = totPellets.Value - numPelletsEaten.Value;
        if(toBeEaten <= levelParams.currentLevel.ghostRed2DotsLeft) {
            return ChangeSpeed(levelParams.currentLevel.ghostRed2Speed);
        } else if(toBeEaten <= levelParams.currentLevel.ghostRed1DotsLeft) {
            return ChangeSpeed(levelParams.currentLevel.ghostRed1Speed);
        }
        return ChangeSpeed(levelParams.currentLevel.ghostSpeed);
    }
}
