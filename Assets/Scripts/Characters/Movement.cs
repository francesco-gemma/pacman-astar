using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour {
    public float speed;
    public Vector2 initialDirection;
    public LayerMask obstacleLayer;

    public Vector2 direction { get; private set; }
    private new Rigidbody2D rigidbody;
    public Vector2 nextDirection { get; private set; }
    private Vector3 startingPosition;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
        SetDirection(initialDirection);
    }

    private void Start() {
        ResetState();
    }

    public void ResetState() {
        direction = initialDirection;
        nextDirection = Vector2.zero;
        transform.position = startingPosition;
        rigidbody.isKinematic = false;
        enabled = true;
    }

    private void Update() {
        // Try to move in the next direction while it's queued to make movements
        // more responsive
        if(nextDirection != Vector2.zero) {
            SetDirection(nextDirection);
        }
    }

    private void FixedUpdate() {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rigidbody.MovePosition(position + translation);
    }

    public void SetDirection(Vector2 direction, bool forced = false) {
        // Only set the direction if the tile in that direction is available
        // otherwise we set it as the next direction so it'll automatically be
        // set when it does become available
        if(forced || !Occupied(direction)) {
            this.direction = direction;
            nextDirection = Vector2.zero;
        } else {
            nextDirection = direction;
        }
    }

    public bool Occupied(Vector2 direction) {
        // If no collider is hit then there is no obstacle in that direction
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.75f, 0f, direction, 1.5f, obstacleLayer);
        return hit.collider != null;
    }

}
