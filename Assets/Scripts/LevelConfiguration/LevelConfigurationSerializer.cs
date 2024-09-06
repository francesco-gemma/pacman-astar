[System.Serializable]
public class LevelConfigurationSerializer {
    public Fields[] fieldsPerLevel;
}

[System.Serializable]
public class Fields {
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
}
