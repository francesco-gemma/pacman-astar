using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class GhostBody : MonoBehaviour {

    private Ghost ghost;

    public UnityEvent onPacmanDeath;

    public GameEvent onGhostEaten;

    private ScoreText scoreText;

    private void Start() {
        ghost = this.GetComponentInParent<Ghost>();
        scoreText = this.GetComponentInChildren<ScoreText>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Pacman") {
            if(ghost.state == GhostStates.FRIGHTENED) {
                ghost.OnGhostEaten();
                onGhostEaten.Raise();
                scoreText.Show();
            } else if(ghost.state == GhostStates.CHASE) {
                onPacmanDeath.Invoke();
            }
        }
    }

}
