using UnityEngine;

public class Rocket : MonoBehaviour {
    
    [SerializeField] float speed;
    [SerializeField] Vector2 range;
    float multiplier;
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();

        Transform planet = GameObject.Find(PlayerPrefs.GetString("NextLevel", "Lumina")).transform;
        GetComponentInChildren<PointingArrow>().target = planet;

        transform.position = new Vector3(
            planet.position.x + Random.Range(range.x, range.y),
            planet.position.y + Random.Range(range.x, range.y)
        );
    }

    private void Update() {
        transform.LookAt2D(Helpers.Mouse);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftControl)) multiplier = 2;
        else multiplier = 1;
    }

    private void FixedUpdate() {
        rb.velocity = transform.right * speed * multiplier * Time.fixedDeltaTime;
    }
}