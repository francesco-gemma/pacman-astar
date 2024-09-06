using UnityEngine;

[CreateAssetMenu(fileName = "Fruit", menuName = "Scriptable Objects/Fruit")]
public class FruitSO : ScriptableObject {
    public new string name;
    public Sprite sprite;
    public int points;
    public int minLevel;
}
