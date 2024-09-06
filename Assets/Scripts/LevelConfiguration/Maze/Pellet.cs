using UnityEngine;
using ScriptableObjectArchitecture;

public class Pellet : MonoBehaviour {

    public GameEvent onPelletEaten;
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Pacman") {
            collision.gameObject.GetComponent<PacmanSpeedChanger>().DotsSpeed();
            this.gameObject.SetActive(false);
            onPelletEaten.Raise();
        }
    }
}
