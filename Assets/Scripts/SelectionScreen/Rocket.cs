using UnityEngine;

public class Rocket : MonoBehaviour {
    
    [SerializeField] float speed;
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        GetComponentInChildren<PointingArrow>().target = GameObject.Find(PlayerPrefs.GetString("NextLevel", "Lumina")).transform;
    }

    private void Update() {
        transform.LookAt2D(Helpers.Mouse);
    }

    private void FixedUpdate() {
        rb.velocity = transform.right * speed * Time.fixedDeltaTime * Mathf.Min(Vector3.Distance(transform.position, Helpers.Mouse) * 0.1f, 1.5f);
    }
}