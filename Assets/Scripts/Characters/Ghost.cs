using UnityEngine;
using Pathfinding;
using ScriptableObjectArchitecture;

public class Ghost : MonoBehaviour {

    public Transform targetDefault;
    public Transform targetOnScatter;
    public Transform targetHome;
    public FloatVariable flashingTime;

    private GhostBody body;
    private GameObject eyes;
    private Color colorDefault;
    private GhostAILerp aiLerp;
    private AIDestinationSetter ai;

    public string state { get; private set; }

    protected virtual void Awake() {
        body = GetComponentInChildren<GhostBody>();
        eyes = GetComponentInChildren<GhostEyes>().gameObject;
        colorDefault = body.GetComponent<SpriteRenderer>().color;
        aiLerp = GetComponent<GhostAILerp>();
        ai = this.GetComponent<AIDestinationSetter>();
        ai.target = targetHome;
        aiLerp.enabled = false;
        state = GhostStates.CAPTURED;
    }

    public void Activate() {
        aiLerp.enabled = true;
        OnPowerEnded();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Node") {
            aiLerp.canSearch = true;
            Node node = other.GetComponent<Node>();
            if(node != null) {
                if(state == GhostStates.FRIGHTENED) {
                    ai.target = node.RandomDirection().transform;
                } else if(state == GhostStates.CHASE) {
                    ai.target = computeTarget();
                }
            }
            Debug.DrawLine(this.transform.position, ai.target.position, this.GetComponentInChildren<SpriteRenderer>().color, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Node") {
            aiLerp.canSearch = false;
            if(state != GhostStates.FRIGHTENED) {
                this.GetComponentInChildren<GhostEyes>().EyeAnimation((aiLerp as IAstarAI).velocity);
            }
        }
    }
    protected virtual Transform computeTarget() {
        return targetDefault;
    }

    public void OnPowerPelletEaten() {
        if(this.state != GhostStates.CAPTURED) {
            this.UpdateState(GhostStates.FRIGHTENED);
            CancelInvoke("OnPowerEnded");
        }
    }
    public void OnPowerEnding() {
        if(state == GhostStates.FRIGHTENED) {
            body.GetComponent<Animator>().SetBool("flashing", true);
            eyes.SetActive(false);
            Invoke("OnPowerEnded", flashingTime.Value);
        }
    }
    public void OnPowerEnded() {
        this.UpdateState(GhostStates.CHASE);
        ai.target = computeTarget();
    }
    public void OnGhostEaten() {
        this.UpdateState(GhostStates.CAPTURED);
        aiLerp.canSearch = true;
        ai.target = targetHome;
    }

    private void UpdateState(string newState) {
        //Debug.Log(this.name + " New state: " + newState);
        this.state = newState;
        SpriteRenderer bodySprite = body.GetComponent<SpriteRenderer>();

        bool isFrightened = state == GhostStates.FRIGHTENED;

        bodySprite.color = isFrightened ? Color.white : colorDefault;
        bodySprite.enabled = state != GhostStates.CAPTURED;

        body.GetComponent<Animator>().SetBool("frightened", isFrightened);
        body.GetComponent<Animator>().SetBool("flashing", false);
        eyes.gameObject.SetActive(!isFrightened);

        GhostSpeedChanger ghostSpeedChanger = this.GetComponent<RedGhostSpeedChanger>();
        if(ghostSpeedChanger == null) {
            ghostSpeedChanger = this.GetComponent<GhostSpeedChanger>();
        }
        ghostSpeedChanger.SwitchSpeed   (isFrightened);

    }

}
