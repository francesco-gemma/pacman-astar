using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;

public class UIScore : MonoBehaviour {

    public IntReference score;

    private void Awake() {
        UpdateText();
    }

    public void AddScore(IntVariable score) {
        this.score.Value += score.Value;
    }

    public void AddScore(CollisionRequest request) {
        this.AddScore(request.points);
    }

    public void UpdateText() {
        this.GetComponent<TextMeshProUGUI>().text = this.score.ToString();
    }

}