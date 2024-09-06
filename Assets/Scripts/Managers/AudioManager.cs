using UnityEngine.Audio;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    public AudioMixerGroup mixerGroup;

    private Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();

    void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    public void PlaySceneMusic(SoundEffectSO sound) {
        AudioSource sceneMusic = this.GetComponent<AudioSource>();
        if(sound != null) {
            sound.Play(sceneMusic);
        } else {
            sceneMusic.clip = null;
            sceneMusic.Stop();
        }
    }

    public void Play(SoundEffectSO sound) {
        string key = sound.name;
        AudioSource source = null;
        if(audioSources.ContainsKey(key)) {
            source = audioSources[key];
        } else {
            source = this.gameObject.AddComponent<AudioSource>();
            audioSources.Add(key, source);
        }
        if(!source.isPlaying || sound.simultaneous) {
            sound.Play(source);
        }
    }
    public void Play(CollisionRequest request) {
        Play(request.soundEffect);
    }
    public void Play(SoundEffectRequest request) {
        Play(request.soundEffect);
    }


}
