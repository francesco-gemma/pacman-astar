using ScriptableObjectArchitecture;
[System.Serializable]
public class CollisionRequest {
    public SoundEffectSO soundEffect;
    public IntVariable points;

    public CollisionRequest(SoundEffectSO soundEffect, IntVariable points) {
        this.soundEffect = soundEffect;
        this.points = points;
    }
}