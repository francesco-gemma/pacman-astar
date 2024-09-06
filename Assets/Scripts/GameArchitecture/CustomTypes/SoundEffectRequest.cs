[System.Serializable]
public class SoundEffectRequest {
    public SoundEffectSO soundEffect;
    public SoundEffectRequest(SoundEffectSO soundEffect) {
        this.soundEffect = soundEffect;
    }
}