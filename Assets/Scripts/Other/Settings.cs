using System;
using UnityEngine;
using UnityEngine.Events;

public class Settings : MonoBehaviour {

    public bool postProcessing;
    public bool fullScreen;
    public bool cameraShake;
    public bool particles;
    public int resolution;
    public int graphicsQuality;
    public float musicVolume;
    public float sfxVolume;

    public static UnityEvent<bool[], int[], float[]> Change = new UnityEvent<bool[], int[], float[]>();
    public static Settings instance;

    private void Start() {
        transform.SetParent(null, false);
        if (instance != null) {
            Destroy(gameObject);
            return;
        }

        // Booleans
        postProcessing = SaveManager.save.postProcessing;
        fullScreen = SaveManager.save.fullscreen;
        cameraShake = SaveManager.save.cameraShake;
        particles = SaveManager.save.particles;

        // Indexes
        resolution = SaveManager.save.resolutionIndex;
        graphicsQuality = SaveManager.save.graphicsQuality;

        // Floats
        musicVolume = SaveManager.save.musicVolume;
        sfxVolume = SaveManager.save.sfxVolume;

        instance = this;
        DontDestroyOnLoad(instance);

        Change.Invoke(
            new bool[] { postProcessing, fullScreen, cameraShake, particles },
            new int[] { resolution, graphicsQuality },
            new float[] { musicVolume, sfxVolume }    
        );

        UnityEngine.SceneManagement.SceneManager.sceneLoaded += (o1, o2) => {
            Change.Invoke(
                new bool[] { postProcessing, fullScreen, cameraShake, particles },
                new int[] { resolution, graphicsQuality },
                new float[] { musicVolume, sfxVolume }    
            );  
        };
    }

    public void Save() {
        // Booleans
        SaveManager.save.postProcessing = postProcessing;
        SaveManager.save.fullscreen = fullScreen;
        SaveManager.save.cameraShake = cameraShake;
        SaveManager.save.particles = particles;

        // Indexes
        SaveManager.save.resolutionIndex = resolution;
        SaveManager.save.graphicsQuality = graphicsQuality;

        // Floats
        SaveManager.save.musicVolume = musicVolume;
        SaveManager.save.sfxVolume = sfxVolume;
        
        Change.Invoke(
            new bool[] { postProcessing, fullScreen, cameraShake, particles },
            new int[] { resolution, graphicsQuality },
            new float[] { musicVolume, sfxVolume }    
        );
    }
}