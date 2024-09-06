
using UnityEngine;

public class OrangeGhost : Ghost {
    protected override Transform computeTarget() {

        Transform pacmanPosition = base.targetDefault;

        float distance = Vector3.Distance(this.transform.position, pacmanPosition.position);

        return distance < 8 ? base.targetOnScatter : pacmanPosition;

    }

}
