using UnityEngine;
using System.Linq;

public class MusicManager : MonoBehaviour {

    [SerializeField] Sound[] music;
    public string playing;
    public string ambience;
    public static MusicManager instance;

    private void Awake() {
        transform.SetParent(null, false);
        if (instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(instance);
        
        foreach (Sound sound in music) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.loop = true;
            sound.source.clip = sound.clip;
        }

        Settings.Change.AddListener((o1, o2, sounds) => {
            foreach (Sound sound in music)
                sound.source.volume = sounds[0] * sound.volume;
        });
    }

    public void Switch(string newSong) {
        if (!string.IsNullOrEmpty(playing)) {
            Sound current = music.Where(sound => sound.name == playing).ToList()[0];
            current.source.Stop();
        }

        Sound song = music.Where(sound => sound.name == newSong).ToList()[0];
        song.source.Play();

        playing = newSong;
    }

    public void SwitchAmbience(string newAmbience) {
        if (!string.IsNullOrEmpty(ambience)) {
            Sound current = music.Where(sound => sound.name == ambience).ToList()[0];
            current.source.Stop();
        }

        if (newAmbience == "none") {
            ambience = "none";
            return;
        }

        Sound song = music.Where(sound => sound.name == newAmbience).ToList()[0];
        song.source.Play();

        ambience = newAmbience;
    }
}