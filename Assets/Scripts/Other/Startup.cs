using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class Startup : MonoBehaviour {

    [SerializeField] TextMeshProUGUI status;
    [SerializeField] Image image;

    private void Start() {
        StartCoroutine(ILoadScene(PlayerPrefs.GetInt("TimesPlayed") == 0));
    }

    private IEnumerator ILoadScene(bool startWait) {
        if (startWait) {
            status.text = "Welcome to Lumina.";
            yield return Helpers.Wait(3f);
        }

        status.DOFade(0f, 1f);
        image.DOColor(new Color(0.1132075f, 0.1132075f, 0.1132075f, 1f), 1f);
        image.transform.DOLocalMove(Vector3.zero, 1f);

        yield return Helpers.Wait(1.5f);
        SceneManager.LoadSceneAsync("Menus");
    }
}