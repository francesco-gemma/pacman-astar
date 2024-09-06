using UnityEngine;

[CreateAssetMenu(fileName = "SaveSystem", menuName = "Scriptable Objects/SaveSystem")]
public class SaveSystem : ScriptableObject {
    public string saveFilename = "savefile.sav";
    public string backupSaveFilename = "savefile.sav.bak";

    public SaveObject saveObject;

    [HideInInspector] public SaveDataSerializer saveData = new SaveDataSerializer();

    public bool SaveGameState() {
        this.saveData.Save(saveObject);
        return this.SaveDataToDisk();
    }

    public bool LoadGameState() {
        bool result = this.LoadSaveDataFromDisk();
        if(result) {
            saveData.Restore(saveObject);
        }
        return result;
    }
    private bool LoadSaveDataFromDisk() {

        if(!FileManager.FileExists(this.saveFilename)) {
            return false;
        }

        bool result = FileManager.LoadFromFile(this.saveFilename, out var json);

        if(result) {
            this.saveData.FromJson(json);
        }

        return result;
    }
    private void CreateEmptySaveFile() {
        FileManager.WriteToFile(saveFilename, "");
    }

    private bool SaveDataToDisk() {
        if(FileManager.MoveFile(saveFilename, backupSaveFilename)) {
            if(FileManager.WriteToFile(saveFilename, saveData.ToJson())) {
                Debug.Log("Save successful");
                return true;
            }
        }
        return false;
    }

}