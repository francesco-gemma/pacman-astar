using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;
using System.Collections;


public class SoundEnded : MonoBehaviour {

    public SoundEffectSO sound;
    public SoundEndedGameEvent soundEndedGameEvent;
    public UnityEvent onSoundEndedEvent;

    public void Play() {
        sound.Play();
        StartCoroutine(InvokeRealtimeCoroutine(sound.Length()));
    }

    private IEnumerator InvokeRealtimeCoroutine(float seconds) {
        yield return new WaitForSecondsRealtime(seconds);
        onSoundEndedEvent?.Invoke();
        soundEndedGameEvent?.Raise();
    }
}
