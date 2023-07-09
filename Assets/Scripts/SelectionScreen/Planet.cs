using UnityEngine;

public class Planet : MonoBehaviour {

    [SerializeField] bool unlocked;
    [SerializeField] float speed;

    private void Awake() {
        if (!unlocked) unlocked = PlayerPrefs.GetInt(gameObject.name + "Unlocked") == 1;
    }

    private void Update() {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (unlocked && other.gameObject.CompareTag("Player"))
            Scenes.Load(name: gameObject.name);
    }
}