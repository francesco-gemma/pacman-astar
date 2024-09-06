public class GhostSpeedChanger : SpeedChanger {

    protected GhostAILerp aiLerp;
    public void OnLevelChange() {
        aiLerp = this.GetComponent<GhostAILerp>();
        DefaultSpeed();
    }
    public void SwitchSpeed(bool isFrightened) {
        aiLerp.speed = isFrightened ? FrightSpeed() : Default();
    }

    public void DefaultSpeed() {
        aiLerp.speed = Default();
    }
    protected override float Default() {
        return ChangeSpeed(levelParams.currentLevel.ghostSpeed);
    }
    public float TunnelSpeed() {
        return ChangeSpeed(levelParams.currentLevel.ghostTunnelSpeed);
    }
    public float FrightSpeed() {
        return ChangeSpeed(levelParams.currentLevel.ghostFrightSpeed);
    }

}
