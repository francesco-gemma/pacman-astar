using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfigurationSO", menuName = "Scriptable Objects/Level Configuration")]
public class LevelConfigurationSO : ScriptableObject {
    public int level;
    public string fruitSymbol;
    public int fruitPoints;
    public float pacmanSpeed;
    public float pacmanDotsSpeed;
    public float pacmanFrightSpeed;
    public float pacmanFrightDotsSpeed;
    public float ghostSpeed;
    public float ghostTunnelSpeed;
    public float ghostFrightSpeed;
    public float frightTimeSec;
    public int numOfFlashes;
    public int ghostRed1DotsLeft;
    public float ghostRed1Speed;
    public int ghostRed2DotsLeft;
    public float ghostRed2Speed;
    public void Initialize(Fields fields) {
        this.level = fields.level;
        this.fruitSymbol = fields.fruitSymbol;
        this.fruitPoints = fields.fruitPoints;
        this.pacmanSpeed = fields.pacmanSpeed;
        this.pacmanDotsSpeed = fields.pacmanDotsSpeed;
        this.pacmanFrightSpeed = fields.pacmanFrightSpeed;
        this.pacmanFrightDotsSpeed = fields.pacmanFrightDotsSpeed;
        this.ghostSpeed = fields.ghostSpeed;
        this.ghostTunnelSpeed = fields.ghostTunnelSpeed;
        this.ghostFrightSpeed = fields.ghostFrightSpeed;
        this.frightTimeSec = fields.frightTimeSec;
        this.numOfFlashes = fields.numOfFlashes;
        this.ghostRed1DotsLeft = fields.ghostRed1DotsLeft;
        this.ghostRed1Speed = fields.ghostRed1Speed;
        this.ghostRed2DotsLeft = fields.ghostRed2DotsLeft;
        this.ghostRed2Speed = fields.ghostRed2Speed;
    }
}