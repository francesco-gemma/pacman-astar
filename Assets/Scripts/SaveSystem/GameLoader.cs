using UnityEngine;
using UnityEngine.UI;


public class GameLoader : MonoBehaviour {
    public SaveSystem saveSystem;
    private void Awake() {
        bool gameExists = saveSystem.LoadGameState();
        this.GetComponent<Button>().interactable = gameExists;
    }

}
