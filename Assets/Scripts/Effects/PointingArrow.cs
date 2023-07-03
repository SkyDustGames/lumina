using UnityEngine;

public class PointingArrow : MonoBehaviour {
    
    [SerializeField] Transform target;
    [SerializeField] GameObject graphics;

    private void FixedUpdate() {
        transform.LookAt2D(target);
        graphics.SetActive(Vector2.Distance(transform.position, target.position) > 5f);
    }
}