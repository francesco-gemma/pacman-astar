using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class Timer : MonoBehaviour {

    private float time;

    public UnityEvent onTimeEnded;

    public void Awake() {
        this.enabled = false;
    }
    public void StartTimer(FloatVariable time) {
        this.time = time.Value;
        this.enabled = true;
        Debug.Log("Started timer: " + time);
    }

    void Update() {
        time -= Time.deltaTime;
        if(time <= 0.0f) {
            onTimeEnded.Invoke();
            this.enabled = false;
        }

    }
}
