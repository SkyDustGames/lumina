using UnityEngine;

public class Planet : MonoBehaviour {

    [SerializeField] bool unlocked;

    private void Awake() {
        if (!unlocked) unlocked = PlayerPrefs.GetInt(gameObject.name + "Unlocked") == 1;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (unlocked && other.gameObject.CompareTag("Player"))
            Scenes.Load(name: gameObject.name);
    }
}