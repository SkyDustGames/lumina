using UnityEngine;

public class Player : MonoBehaviour {
    
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] int maxJumpCount;
    int jumps;
    float movement;
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        movement = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && jumps < maxJumpCount) {
            jumps++;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(speed * movement * Time.deltaTime, rb.velocity.y);
    }

    private void OnCollisionExit2D(Collision2D other) {
        jumps = maxJumpCount / 2;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        jumps = 0;
    }
}