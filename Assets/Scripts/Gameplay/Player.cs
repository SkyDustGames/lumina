using UnityEngine;

public class Player : MonoBehaviour {
    
    [SerializeField] float speed;
    Animator animator;
    Vector2 movement;
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        animator.SetBool("Walking", movement.x < 0 || movement.x > 0 || movement.y < 0 || movement.y > 0);
    }

    private void FixedUpdate() {
        rb.velocity = movement * speed * Time.deltaTime;
    }
}