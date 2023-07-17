using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour {
    
    [SerializeField] Boss trigger;
    [SerializeField] BoxCollider2D triggerCollider;
    [SerializeField] Vector3 cameraPos;
    [SerializeField] Sprite closed;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            MusicManager.instance.Switch("Bossfight");
            Helpers.Camera.DOOrthoSize(10f, 1f);
            Helpers.Camera.transform.DOMove(cameraPos, 1f);
            Destroy(Helpers.Camera.GetComponent<CameraFollow>());

            if (trigger != null) trigger.StartFight();
            Destroy(triggerCollider);
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().sprite = closed;
        }
    }
}