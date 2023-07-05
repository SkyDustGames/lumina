using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField] string nextLevel;
    public static LevelManager instance;

    private void Awake() {
        instance = this;
    }

    public void GoToNextLevel() {
        PlayerPrefs.SetInt(nextLevel + "Unlocked", 1);
        PlayerPrefs.SetString("NextLevel", nextLevel);
        Scenes.Load(name: "WorldSelectionScreen");
    }
}