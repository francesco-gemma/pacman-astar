using UnityEngine;


public class GameSaver : MonoBehaviour {
    public SaveSystem saveSystem;
    public void SaveGame() {
        bool isGameSaved = saveSystem.SaveGameState();
        if(isGameSaved) {
            this.GetComponent<SoundEnded>().Play();
        }
    }

}
