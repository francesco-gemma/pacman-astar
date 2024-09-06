using UnityEngine;
using ScriptableObjectArchitecture;

public class Fruit : MonoBehaviour {

    public GameObject spawnableNodes;
    public FruitSO[] fruits;
    public IntReference numPelletsEaten;
    public IntReference level;

    private SpriteRenderer spriteRenderer;
    private new Collider2D collider;
    private void Awake() {
        UpdateFruit();
    }

    public void UpdateFruit() {
        foreach(FruitSO fruit in fruits) {
            if(level.Value >= fruit.minLevel) {
                spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = fruit.sprite;
                collider = GetComponent<Collider2D>();
                GetComponent<CollisionCue>().points.Value = fruit.points;
                break;
            }
        }
        Hide();
    }
    public void Spawn() {
        Transform nodes = spawnableNodes.transform;
        System.Random rnd = new System.Random();
        int index = rnd.Next(nodes.childCount);
        this.transform.position = nodes.GetChild(index).position;

        spriteRenderer.enabled = true;
        collider.enabled = true;
    }
    public void Hide() {
        spriteRenderer.enabled = false;
        collider.enabled = false;
    }

    public bool IsSpawned() {
        return spriteRenderer.enabled;
    }
}
