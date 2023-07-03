using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DialogManager : MonoBehaviour {
    
    [SerializeField] CanvasGroup panel;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image image;
    Dialog dialog;
    int index;

    public static DialogManager instance;

    private void Awake() {
        instance = this;
    }

    private void Update() {
        if (dialog != null && Input.GetKeyDown(KeyCode.Return)) {
            index++;
            if (index >= dialog.elements.Length) {
                dialog = null;
                panel.DOFade(0f, .5f);
                return;
            }

            text.text = dialog.elements[index].text;
            image.sprite = dialog.elements[index].sprite;
        }
    }

    public void TriggerDialog(Dialog dialog) {
        this.dialog = dialog;

        index = 0;
        text.text = dialog.elements[index].text;
        image.sprite = dialog.elements[index].sprite;

        panel.DOFade(1f, .5f);
    }
}