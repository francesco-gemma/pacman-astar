using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "NewSoundEffect", menuName = "Scriptable Objects/Audio/New Sound Effect")]
public class SoundEffectSO : ScriptableObject {
    #region config

    private static readonly float SEMITONES_TO_PITCH_CONVERSION_UNIT = 1.05946f;
    public AudioClip[] clips;
    public bool loop;
    public bool destroySource;
    public bool simultaneous;

    public Vector2 volume = new Vector2(0.5f, 0.5f);

    //Pitch / Semitones
    public bool useSemitones;

    public Vector2Int semitones = new Vector2Int(0, 0);

    public Vector2 pitch = new Vector2(1, 1);

    [SerializeField] private SoundClipPlayOrder playOrder;

    [SerializeField] private int playIndex = 0;

    #endregion

    #region PreviewCode

#if UNITY_EDITOR
    private AudioSource previewer;

    private void OnEnable() {
        previewer = EditorUtility
            .CreateGameObjectWithHideFlags("AudioPreview", HideFlags.HideAndDontSave,
                typeof(AudioSource))
            .GetComponent<AudioSource>();
    }

    private void OnDisable() {
        DestroyImmediate(previewer.gameObject);
    }


    private void PlayPreview() {
        Play(previewer);
    }

    private void StopPreview() {
        previewer.Stop();
    }
#endif

    #endregion

    public void SyncPitchAndSemitones() {
        if(useSemitones) {
            pitch.x = Mathf.Pow(SEMITONES_TO_PITCH_CONVERSION_UNIT, semitones.x);
            pitch.y = Mathf.Pow(SEMITONES_TO_PITCH_CONVERSION_UNIT, semitones.y);
        } else {
            semitones.x = Mathf.RoundToInt(Mathf.Log10(pitch.x) / Mathf.Log10(SEMITONES_TO_PITCH_CONVERSION_UNIT));
            semitones.y = Mathf.RoundToInt(Mathf.Log10(pitch.y) / Mathf.Log10(SEMITONES_TO_PITCH_CONVERSION_UNIT));
        }
    }

    private AudioClip GetAudioClip() {
        // get current clip
        var clip = clips[playIndex >= clips.Length ? 0 : playIndex];

        // find next clip
        switch(playOrder) {
            case SoundClipPlayOrder.in_order:
                playIndex = (playIndex + 1) % clips.Length;
                break;
            case SoundClipPlayOrder.random:
                playIndex = Random.Range(0, clips.Length);
                break;
            case SoundClipPlayOrder.reverse:
                playIndex = (playIndex + clips.Length - 1) % clips.Length;
                break;
        }

        // return clip
        return clip;
    }

    public float Length() {
        float length = 0f;
        foreach(var audio in clips) {
            length += audio.length;
        }
        return length;
    }

    public void Play() {
        Play(null);
    }

    public AudioSource Play(AudioSource audioSourceParam = null) {
        if(clips.Length == 0) {
            Debug.LogWarning($"Missing sound clips for {name}");
            return null;
        }

        var source = audioSourceParam;
        if(source == null) {
            var _obj = new GameObject("Sound", typeof(AudioSource));
            source = _obj.GetComponent<AudioSource>();
        }

        // set source config:
        source.clip = GetAudioClip();
        source.volume = Random.Range(volume.x, volume.y);
        source.pitch = useSemitones
            ? Mathf.Pow(SEMITONES_TO_PITCH_CONVERSION_UNIT, Random.Range(semitones.x, semitones.y))
            : Random.Range(pitch.x, pitch.y);
        source.loop = loop;
        source.Play();

#if UNITY_EDITOR
        if(source != previewer && destroySource) {
            Destroy(source.gameObject, source.clip.length);
        }
#endif
        return source;
    }

    enum SoundClipPlayOrder {
        random,
        in_order,
        reverse
    }
}
