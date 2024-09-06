using UnityEngine;

public class GhostEyes : MonoBehaviour {
    public Sprite down;
    public Sprite left;
    public Sprite up;
    public Sprite right;

    public void EyeAnimation(Vector2 velocity) {
        SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();

        Vector2 norm = velocity.normalized;

        if(norm == Vector2.up) {
            sprite.sprite = up;
        } else if(norm == Vector2.down) {
            sprite.sprite = down;
        } else if(norm == Vector2.left) {
            sprite.sprite = left;
        } else if(norm == Vector2.right) {
            sprite.sprite = right;
        }

    }
}
