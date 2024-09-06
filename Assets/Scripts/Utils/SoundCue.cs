using UnityEngine;
using ScriptableObjectArchitecture;

public class SoundCue : MonoBehaviour {

    public SoundEffectSO soundEffect;

    [Header("Broadcasting events")]
    public SoundEffectRequestGameEvent soundEvent;

    public void SoundRequest() {
        var request = new SoundEffectRequest(soundEffect);
        soundEvent.Raise(request);
    }
}
