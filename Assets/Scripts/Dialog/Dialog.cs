using UnityEngine;

[CreateAssetMenu(menuName = "Dialog")]
public class Dialog : ScriptableObject {

    [System.Serializable]
    public class DialogElement {

        public Sprite sprite;
        public string text;
    }

    public DialogElement[] elements;
}