using System.Collections;
using DG.Tweening;
using UnityEngine;

public class UIManager : MonoBehaviour {

    [SerializeField] Transform active;

    private void Awake() {
        Activate(active);
    }

    public void Activate(Transform t) {
        StartCoroutine(IActivate(t));
        AudioManager.instance.PlaySound("Interact");
    }

    private IEnumerator IActivate(Transform t) {
        if (active != null) {
            active.DOLocalMoveX(-600, .5f);
            yield return Helpers.Wait(.5f);

            active.gameObject.SetActive(false);
        }
        
        active = t;
        active.gameObject.SetActive(true);
        active.DOLocalMoveX(-200, .5f);
    }
}