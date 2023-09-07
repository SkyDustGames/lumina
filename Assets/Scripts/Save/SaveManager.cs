using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveManager {

    private static readonly string path = Path.Join(Application.persistentDataPath, "lumina.save");
    public static Save save;

    [RuntimeInitializeOnLoadMethod]
    public static void Init() {
        Load();
        Application.quitting += Save;
    }

    private static void Load() {
        if (!File.Exists(path)) {
            save = new Save();
            return;
        }

        BinaryFormatter formatter = new();
        FileStream stream = new(path, FileMode.OpenOrCreate);
        save = formatter.Deserialize(stream) as Save;
        stream.Close();
    }

    private static void Save() {
        BinaryFormatter formatter = new();
        FileStream stream = new(path, FileMode.Create);
        formatter.Serialize(stream, save);
        stream.Close();
    }
}