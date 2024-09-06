using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;

public class ScoreText : MonoBehaviour {

    public IntReference score;

    private TextMeshPro textMeshPro;

    public void Awake() {
        this.textMeshPro = this.GetComponent<TextMeshPro>();
    }
    public void Show() {
        this.textMeshPro.text = this.score.Value.ToString();
        this.textMeshPro.enabled = true;
        Invoke("Hide", 1.0f);
    }

    private void Hide() {
        this.textMeshPro.enabled = false;
    }

}