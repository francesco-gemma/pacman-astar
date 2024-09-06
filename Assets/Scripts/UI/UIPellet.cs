using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;

public class UIPellet : MonoBehaviour {

    public IntReference numPelletsEaten;

    public IntReference totPellets;

    public void UpdateText() {
        this.GetComponent<TextMeshProUGUI>().text = $"{numPelletsEaten.Value} / {totPellets.Value}";
    }

}