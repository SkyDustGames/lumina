using UnityEngine;
using DG.Tweening;

public class PauseMenu : MonoBehaviour {

    public static bool gameIsPaused;

    [SerializeField] Transform background;
    CanvasGroup group;
    string lastPlayed;

    private void Awake() {
        group = GetComponent<CanvasGroup>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    public void TogglePause() {
        gameIsPaused = !gameIsPaused;
        group.interactable = gameIsPaused;
        group.blocksRaycasts = gameIsPaused;
        Time.timeScale = gameIsPaused? 0f : 1f;
        
        group.DOFade(gameIsPaused ? 1f : 0f, .5f).SetUpdate(true);
        background.DOLocalMoveX(200 * (gameIsPaused? 1 : -1) - 400, .5f).SetUpdate(true);
        AudioManager.instance.PlaySound("Interact");

        if (gameIsPaused) {
            lastPlayed = MusicManager.instance.playing;
            MusicManager.instance.Switch(null, true);
        } else MusicManager.instance.Switch(lastPlayed, true);
    }

    public void Quit() {
        Scenes.Load(name: "Menus");
        AudioManager.instance.PlaySound("Interact");
    }
}