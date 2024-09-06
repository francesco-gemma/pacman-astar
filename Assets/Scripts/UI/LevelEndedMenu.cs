using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;

public class LevelEndedMenu : MonoBehaviour {

    public BoolReference levelWon;
    public IntReference lives;
    public IntReference livesDefault;

    public GameObject nextLevelButton;
    public GameObject saveButton;
    public GameObject newGameButton;

    public void UpdateButtons() {
        if(lives.Value > 0) {
            nextLevelButton.SetActive(true);
            newGameButton.SetActive(false);
            nextLevelButton.GetComponentInChildren<TextMeshProUGUI>().text = levelWon.Value ? "NEXT LEVEL" : "RETRY";
        } else {
            nextLevelButton.SetActive(false);
            newGameButton.SetActive(true);
            this.GetComponent<Menu>().firstSelected = newGameButton;
        }
        saveButton.SetActive(levelWon.Value);
    }
}
