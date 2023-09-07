using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField] string nextLevel;
    public static LevelManager instance;

    private void Awake() {
        instance = this;
    }

    public void GoToNextLevel() {
        if (nextLevel == "Menus") {
            SaveManager.save = new();
            Scenes.Load(index: 0);
            return;
        }

        if (string.IsNullOrEmpty(nextLevel)) {
            Scenes.Load(name: "ToBeContinued");
            return;
        }

        if (!SaveManager.save.unlockedPlanets.Contains(nextLevel))
            SaveManager.save.unlockedPlanets.Add(nextLevel);
        SaveManager.save.nextPlanet = nextLevel;
        Scenes.Load(name: "WorldSelectionScreen");
    }
}