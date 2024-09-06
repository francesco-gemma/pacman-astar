using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public List<Node> connectedNodes { get; private set; }

    private void Start() {
        connectedNodes = new List<Node>(4);
        Vector2[] directions = { Vector2.right, Vector2.down, Vector2.up, Vector2.left };

        foreach(Vector2 dir in directions) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, Mathf.Infinity, 1 << this.gameObject.layer);

            if(hit.collider != null) {
                connectedNodes.Add(hit.collider.gameObject.GetComponent<Node>());
            }
        }

    }

    //private void LateUpdate() {
    //    foreach(Node n in connectedNodes) {
    //        Debug.DrawLine(this.transform.position, n.transform.position, Color.yellow, 0.5f);
    //    }
    //}

    public Node RandomDirection() {
        System.Random rnd = new System.Random();
        int index = rnd.Next(this.connectedNodes.Count);
        return connectedNodes[index];
    }

}
