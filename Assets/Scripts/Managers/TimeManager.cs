using UnityEngine;

public class TimeManager : MonoBehaviour {
    public void Pause() {
        SetTimeScale(0.0f);
    }
    public void Resume() {
        SetTimeScale(1.0f);
    }
    public void SetTimeScale(float scale) {
        Time.timeScale = scale;
    }
}
