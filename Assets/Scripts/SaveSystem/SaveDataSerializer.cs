using UnityEngine;

[System.Serializable]
public class SaveDataSerializer {
    public int score;
    public int level;
    public int lives;
    public bool levelWon;
    public void DefaultData() {
        this.score = 0;
        this.level = 0;
        this.lives = 0;
        this.levelWon = false;
    }

    public void Restore(SaveObject saveObject) {
        saveObject.score.Value = this.score;
        saveObject.level.Value = this.level;
        saveObject.lives.Value = this.lives;
        saveObject.levelWon.Value = this.levelWon;
    }

    public void Save(SaveObject saveObject) {
        this.score = saveObject.score.Value;
        this.level = saveObject.level.Value;
        this.lives = saveObject.lives.Value;
        this.levelWon = saveObject.levelWon.Value;
    }
    public string ToJson() {
        return JsonUtility.ToJson(this);
    }

    public void FromJson(string json) {
        JsonUtility.FromJsonOverwrite(json, this);
    }
}