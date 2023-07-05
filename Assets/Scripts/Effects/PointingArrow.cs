using UnityEngine;

public class PointingArrow : MonoBehaviour {
    
    public Transform target;
    [SerializeField] GameObject graphics;

    private void Update() {
        transform.LookAt2D(target);
        graphics.SetActive(true);
    }
}