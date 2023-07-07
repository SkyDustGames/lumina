using UnityEngine;

public class Player : MonoBehaviour {
    
    [SerializeField] float speed;
    Vector2 movement;
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate() {
        rb.velocity = movement * speed * Time.deltaTime;
    }
}