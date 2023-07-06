using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour {
    
    [SerializeField] CanvasGroup panel;
    private static Scenes instance;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(instance);

        panel.alpha = 1;
        SceneManager.sceneLoaded += (scene, mode) => {
            Time.timeScale = 1f;
            panel.DOFade(0f, .5f);
        };
    }

    public async static void Load(string name = null, int index = -1) {
        instance.panel.DOFade(1f, .5f).SetUpdate(true);
        await Task.Delay(500);

        AsyncOperation operation;

        if (name == null)
            operation = SceneManager.LoadSceneAsync(index);
        else
            operation = SceneManager.LoadSceneAsync(name);
    }

    public static void Reload() {
        Load(index: SceneManager.GetActiveScene().buildIndex);
    }
}