using UnityEngine;

public class Player : MonoBehaviour {
    
    [SerializeField] float speed;
    [HideInInspector] public bool inputEnabled;
    Animator animator;
    Vector2 movement;
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        inputEnabled = true;
    }

    private void Update() {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) *
                    (inputEnabled? 1 : 0);
        animator.SetBool("Walking", movement.x < 0 || movement.x > 0 || movement.y < 0 || movement.y > 0);
    }

    private void FixedUpdate() {
        rb.velocity = movement * speed * Time.deltaTime;
    }
}