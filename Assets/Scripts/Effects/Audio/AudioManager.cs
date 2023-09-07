using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour {

    [SerializeField] Sound[] sounds;
    public static AudioManager instance;

    private void Awake() {
        transform.SetParent(null, false);
        if (instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(instance);

        foreach (Sound sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
        }
    }

    public void PlaySound(string name) {
        Sound sound = sounds.Where(sound => sound.name == name).ToList()[0];
        if (sound != null) {
            sound.source.pitch = Random.Range(1f, 2f);
            sound.source.volume = Settings.instance.sfxVolume * sound.volume;
            sound.source.Play();
        }
    }
}