using UnityEngine;

public class MapInputDetector : MonoBehaviour {
    
    [SerializeField] GameObject bigMap;
    Player player;

    private void Awake() {
        player = FindObjectOfType<Player>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            bool active = bigMap.activeInHierarchy;
            bigMap.SetActive(!active);
            player.inputEnabled = active;
        }
    }
}