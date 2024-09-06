using Pathfinding;
public class GhostAILerp : AILerp {

    public override void OnTargetReached() {
        Ghost ghost = this.GetComponent<Ghost>();
        if(ghost.targetHome.position == this.position) {
            Invoke("Do", 2.0f);
        }
    }

    private void Do() {
        this.GetComponent<Ghost>().OnPowerEnded();
    }

}
