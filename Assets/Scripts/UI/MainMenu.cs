using UnityEngine;

public class MainMenu : MonoBehaviour {

    public void Play() {
        int times = SaveManager.save.timesPlayed;

        string n = "WorldSelectionScreen";
        if (times == 0)
            n = "Lumina";

        SaveManager.save.timesPlayed++;
        Scenes.Load(name: n);
        AudioManager.instance.PlaySound("Interact");
    }

    public void Quit() {
        Application.Quit();
        AudioManager.instance.PlaySound("Interact");
    }
}