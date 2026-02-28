using System.IO;
using PlayerScripts;
using UnityEngine;

namespace Saving
{
    public class SaveDataMapper
    {
        private readonly string savePath = Application.persistentDataPath + "/savedata.json";

        public void SaveGame(GameData data)
        {
            Debug.Log(JsonUtility.ToJson(data));
            // Turn the GameData object into JSON
            var json = JsonUtility.ToJson(data);
            // Write the JSON into the savedata file
            File.WriteAllText(savePath, json);
        }

        public GameData LoadGame()
        {
            // If the file doesn't exist, return null
            if (!File.Exists(savePath)) return null;
            // Read JSON from the savedata file
            var json = File.ReadAllText(savePath);
            // Return a newly created GameData object
            return JsonUtility.FromJson<GameData>(json);
        }
    }
}