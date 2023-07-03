using UnityEngine;

public class Rocket : MonoBehaviour {
    
    [SerializeField] float speed;
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        transform.LookAt2D(Helpers.Mouse);
    }

    private void FixedUpdate() {
        rb.velocity = transform.right * speed * Time.fixedDeltaTime;
    }
}