using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Passage : MonoBehaviour {
    public Transform otherPassage;
    public float shift;

    private void OnTriggerEnter2D(Collider2D other) {
        other.GetComponent<Rigidbody2D>().position = otherPassage.position + new Vector3(shift, 0, 0);
    }

}
