using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class LevelConfigurationGenerator : MonoBehaviour {
    private string sourcePath = Application.streamingAssetsPath;
    private string sourceFile = "levels.json";
    private string destPath = "Assets/ScriptableObjects";
    private string destFolder = "LevelConfiguration";

    public LevelConfigurationSerializer serializer = new LevelConfigurationSerializer();

    public void Start() {

        string sourceFullPath = Path.Combine(sourcePath, sourceFile);
        string json = "";
        try {
            json = File.ReadAllText(sourceFullPath);
        } catch(Exception e) {
            Debug.LogError($"Failed to read from {sourceFullPath} with exception {e}");
        }

        serializer = JsonUtility.FromJson<LevelConfigurationSerializer>(json);

        string path = $"{destPath}/{destFolder}";

        AssetDatabase.DeleteAsset(path);
        AssetDatabase.CreateFolder(destPath, destFolder);

        foreach(Fields fields in serializer.fieldsPerLevel) {
            LevelConfigurationSO so = ScriptableObject.CreateInstance<LevelConfigurationSO>();
            so.Initialize(fields);
            AssetDatabase.CreateAsset(so, $"{path}/LevelConfiguration{so.level}.asset");
        }
        AssetDatabase.SaveAssets();
    }
}