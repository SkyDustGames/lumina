using UnityEngine;

public class MusicToggle : MonoBehaviour {

    [SerializeField] string song;
    [SerializeField] string ambience;

    private void Start() {
        if (MusicManager.instance.playing != song)
            MusicManager.instance.Switch(song);

        if (MusicManager.instance.ambience != ambience)
            MusicManager.instance.SwitchAmbience(ambience);

        Destroy(gameObject);
    }
}