using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class CollisionCue : MonoBehaviour {

    public SoundEffectSO soundEffect;
    public IntVariable points;
    public bool activeAfterCollision;
    public UnityEvent onCollision;

    [Header("Broadcasting events")]
    public CollisionRequestGameEvent collisionEvent;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Pacman") {
            this.gameObject.SetActive(activeAfterCollision);
            var request = new CollisionRequest(soundEffect, points);
            this.collisionEvent.Raise(request);
            onCollision.Invoke();
        }
    }
}
