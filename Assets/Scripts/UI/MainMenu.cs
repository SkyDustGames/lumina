using UnityEngine;

public class MainMenu : MonoBehaviour {

    public void Play() {
        int times = PlayerPrefs.GetInt("TimesPlayed", 0);

        string n = "WorldSelectionScreen";
        if (times == 0)
            n = "Lumina";

        PlayerPrefs.SetInt("TimesPlayed", times + 1);
        Scenes.Load(name: n);
    }

    public void Quit() {
        Application.Quit();
    }
}