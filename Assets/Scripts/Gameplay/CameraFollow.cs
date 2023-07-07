using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] Vector3 offset;
    [SerializeField] float t;
    [SerializeField] Transform target;

    private void FixedUpdate() {
        if (target == null) return;
        transform.position = Vector3.Lerp(transform.position, target.position + offset, t);
    }
}