
using UnityEngine;

public class BlueGhost : Ghost {
    public Transform redGhostPosition;
    private GameObject target;

    protected override void Awake() {
        target = new GameObject("BlueTarget");
        base.Awake();
    }
    protected override Transform computeTarget() {
        Vector3 start = redGhostPosition.position;
        Vector3 newTargetDirection = (base.targetDefault.position - start);
        Vector3 newTarget = newTargetDirection + base.targetDefault.position;

        target.transform.position = newTarget;

        return target.transform;
    }
}
