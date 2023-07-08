using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour {
    
    PostProcessVolume volume;
    PostProcessLayer layer;

    private void Awake() {
        volume = GetComponent<PostProcessVolume>();
        layer = GetComponent<PostProcessLayer>();

        Settings.Change.AddListener((bools, o1, o2) => {
            volume.enabled = bools[0];
            layer.enabled = bools[0];
        });
    }
}