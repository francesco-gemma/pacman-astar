using UnityEngine;
using ScriptableObjectArchitecture;
public class ExtraLife : MonoBehaviour {

    public IntReference score;
    public IntReference lives;

    public void OnEnable() {
        this.gameObject.SetActive(!ExtraLifeGiven());
    }

    [SerializeField]
    private int LIFE_THRESHOLD = 10_000;
    public void OnScoreChange() {
        if(ExtraLifeGiven()) {
            lives.Value++;
            this.GetComponent<SoundCue>().SoundRequest();
            this.gameObject.SetActive(false);
        }
    }

    private bool ExtraLifeGiven() {
        return score.Value >= LIFE_THRESHOLD;
    }
}