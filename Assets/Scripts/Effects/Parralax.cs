using UnityEngine;

public class Parralax : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float max;
    [SerializeField] float start;

    private void Update() {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.localPosition.x <= max) {
            transform.localPosition = new Vector3(start, 0, 10);
        }
    }
}