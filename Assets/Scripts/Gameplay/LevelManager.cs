using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField] string nextLevel;
    public static LevelManager instance;

    private void Awake() {
        instance = this;
    }

    public void GoToNextLevel() {
        if (nextLevel == "Menus") {
            PlayerPrefs.DeleteAll();
            Scenes.Load(index: 0);
            return;
        }

        PlayerPrefs.SetInt(nextLevel + "Unlocked", 1);
        PlayerPrefs.SetString("NextLevel", nextLevel);
        Scenes.Load(name: "WorldSelectionScreen");
    }
}