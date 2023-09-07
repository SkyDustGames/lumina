using UnityEngine;

public class Planet : MonoBehaviour {

    bool unlocked;
    [SerializeField] float speed;

    private void Awake() {
        unlocked = SaveManager.save.unlockedPlanets.Contains(gameObject.name);
        if (!unlocked) GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f, .5f);
    }

    private void Update() {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (unlocked && other.gameObject.CompareTag("Player"))
            Scenes.Load(name: gameObject.name);
    }
}