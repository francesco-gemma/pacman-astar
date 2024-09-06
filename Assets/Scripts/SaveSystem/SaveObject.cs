using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(fileName = "SaveObject", menuName = "Scriptable Objects/Save Object")]
public class SaveObject : ScriptableObject {
    public IntReference score;
    public IntReference level;
    public IntReference lives;
    public BoolReference levelWon;
}