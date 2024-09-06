using UnityEngine;
using System.Collections.Generic;
using ScriptableObjectArchitecture;

[CreateAssetMenu(fileName = "LevelParams", menuName = "Scriptable Objects/Level Params")]
public class LevelParams : ScriptableObject {
    public LevelConfigurationSO currentLevel;
    public LevelConfigurationSO[] assets;
    public LevelConfigurationSOGameEvent onLevelParamsChange;
    private Dictionary<int, LevelConfigurationSO> levels;

    public void Awake() {
        if(levels == null) {
            Debug.Log("Starting level configuration");
            levels = new Dictionary<int, LevelConfigurationSO>();
            foreach(LevelConfigurationSO asset in assets) {
                levels.Add(asset.level, asset);
            }
        }
    }

    public void UpdateLevelConfiguration(int level) {
        int key = level <= levels.Count ? level : levels.Count;
        this.currentLevel = levels[key];
        onLevelParamsChange.Raise(this.currentLevel);
    }

}