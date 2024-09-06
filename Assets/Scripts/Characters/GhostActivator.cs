using UnityEngine;
public class GhostActivator : MonoBehaviour {

    public float leavingTime;
    public void SetupGhost() {
        Invoke("Activate", leavingTime);
    }
    private void Activate() {
        Ghost ghost = this.GetComponent<Ghost>();
        ghost.Activate();
    }

}
