using UnityEngine;

public class SpriteRotation : MonoBehaviour {

    public void Rotate(Vector2 direction) {
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void Reset() {
        Rotate(Vector2.right);
    }

}