using UnityEngine;

public class MainMenu : MonoBehaviour {

    public void Play() {
        int times = PlayerPrefs.GetInt("TimesPlayed", 0);

        string n = "WorldSelectionScreen";
        if (times == 0)
            n = "Lumina";

        PlayerPrefs.SetInt("TimesPlayed", times + 1);
        Scenes.Load(name: n);
        AudioManager.instance.PlaySound("Interact");
    }

    public void Quit() {
        Application.Quit();
        AudioManager.instance.PlaySound("Interact");
    }
}