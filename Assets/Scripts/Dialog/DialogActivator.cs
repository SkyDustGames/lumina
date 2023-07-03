using UnityEngine;
using DG.Tweening;

public class DialogActivator : MonoBehaviour {
    
    [SerializeField] Dialog dialog;
    [SerializeField] SpriteRenderer popup;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
            popup.DOFade(1f, .5f);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
            popup.DOFade(0f, .5f);
    }


    private void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("Player")) {
            DialogManager.instance.TriggerDialog(dialog);
        }
    }
}