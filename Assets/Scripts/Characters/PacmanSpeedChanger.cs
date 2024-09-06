using UnityEngine;
using System.Collections;
public class PacmanSpeedChanger : SpeedChanger {

    public bool powerPelletEaten;

    private Movement movement;
    public void OnLevelChange() {
        movement = this.GetComponent<Movement>();
        DefaultSpeed();
    }

    protected override float Default() {
        float vel = powerPelletEaten ? levelParams.currentLevel.pacmanFrightSpeed : levelParams.currentLevel.pacmanSpeed;
        return ChangeSpeed(vel);
    }

    public void DefaultSpeed() {
        movement.speed = Default();
    }
    public void DotsSpeed() {
        if(powerPelletEaten) {
            movement.speed = ChangeSpeed(levelParams.currentLevel.pacmanFrightDotsSpeed);
        } else {
            movement.speed = ChangeSpeed(levelParams.currentLevel.pacmanDotsSpeed);
        }
    }
    public void OnPowerPelletEaten() {
        powerPelletEaten = true;
        DotsSpeed();
        StartCoroutine(IsPacmanEating());
    }

    public void OnPowerEnded() {
        powerPelletEaten = false;
        movement.speed = Default();
    }

    public void OnPelletEaten() {
        DotsSpeed();
        StartCoroutine(IsPacmanEating());
    }

    private IEnumerator IsPacmanEating() {
        yield return new WaitForSeconds(1.0f);
        LayerMask layer = LayerMask.NameToLayer("Pellet");
        if(!this.GetComponent<Collider2D>().IsTouchingLayers(layer)) {
            //Debug.Log("Pacman is not eating anymore");
            DefaultSpeed();
        }
    }

 

}
