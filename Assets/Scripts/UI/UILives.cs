using UnityEngine;
using ScriptableObjectArchitecture;

public class UILives : MonoBehaviour {
    public IntReference lives;
    public GameObject lifePrefab;

    private void Awake() {
        int children = this.transform.childCount;
        for(int i = children; i < lives.Value; i++) {
            Instantiate(lifePrefab, this.transform);
        }
    }

    public void DrawLives() {
        int children = this.transform.childCount;
        if(children < lives.Value) {
            for(int i = 0; i < lives.Value - children; i++) {
                Instantiate(lifePrefab, this.transform);
            }
        } else if(children > lives.Value) {
            for(int i = 0; i < children - lives.Value; i++) {
                Transform lastchild = this.transform.GetChild(children - 1 - i);
                Destroy(lastchild.gameObject);
            }
        }
    }
}
