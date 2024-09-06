using UnityEngine;
using ScriptableObjectArchitecture;

public class PelletCounter : MonoBehaviour {

    public IntReference numPelletsEaten;
    public IntReference totPellets;
    public BoolReference levelWon;
    public GameEvent onLevelEnded;

    public Fruit fruit;

    private int FRUIT_FIRST_THRESHOLD = 70;
    private int FRUIT_SECOND_THRESHOLD = 170;
    private void Awake() {
        numPelletsEaten.Value = 0;
        totPellets.Value = GameObject.Find("Pellets").transform.childCount;
    }

    public void Add() {
        this.numPelletsEaten.Value++;

        if(numPelletsEaten.Value == FRUIT_FIRST_THRESHOLD || !fruit.IsSpawned() && numPelletsEaten.Value == FRUIT_SECOND_THRESHOLD) {
            fruit.Spawn();
        }

        if(numPelletsEaten.Value == totPellets.Value) {
            levelWon.Value = true;
            onLevelEnded.Raise();
        }
    }

}
