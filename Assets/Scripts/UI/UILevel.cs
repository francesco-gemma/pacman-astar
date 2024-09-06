using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;

public class UILevel : MonoBehaviour {

    public IntReference level;

    private void Awake() {
        UpdateText();
    }

    public void UpdateText() {
        this.GetComponent<TextMeshProUGUI>().text = level.Value.ToString();
    }

}