using ScriptableObjectArchitecture;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LoadingScreenUI : MonoBehaviour
{
    [Header("Broadcasting on channels")]
    public BoolGameEvent loadingScreenToggled;

    [Header("Private Dependencies")]
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Function that will be called from SceneLoaderManager
    public void ToggleScreen(bool enable)
    {
        _animator.SetTrigger(enable ? "Show" : "Hide");
    }

    // Function that will be called from Animator at the end of the clip
    public void SendLoadingScreenShownEvent()
    {
        loadingScreenToggled.Raise(true);
    }

    // Function that will be called from Animator at the end of the clip
    public void SendLoadingScreenHiddenEvent()
    {
        loadingScreenToggled.Raise(false);
    }
}