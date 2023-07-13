using UnityEngine;

public class Rocket : MonoBehaviour {
    
    [SerializeField] float speed;
    [SerializeField] float range;
    float multiplier;
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();

        Transform planet = GameObject.Find(PlayerPrefs.GetString("NextLevel", "Lumina")).transform;
        GetComponentInChildren<PointingArrow>().target = planet;

        transform.position = new Vector3(Random.Range(planet.position.x - range, planet.position.x + range), Random.Range(planet.position.y - range, planet.position.y + range));
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