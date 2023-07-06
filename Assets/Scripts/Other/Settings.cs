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
        postProcessing = PlayerPrefs.GetInt("SettingsPostProcessing", 1) == 1;
        fullScreen = PlayerPrefs.GetInt("SettingsFullScreen", 1) == 1;
        cameraShake = PlayerPrefs.GetInt("SettingsCameraShake", 1) == 1;
        particles = PlayerPrefs.GetInt("SettingsParticles", 1) == 1;

        // Indexes
        resolution = PlayerPrefs.GetInt("SettingsResolution", Array.IndexOf(Screen.resolutions, Screen.currentResolution));
        graphicsQuality = PlayerPrefs.GetInt("SettingsGraphicsQuality", QualitySettings.GetQualityLevel());

        // Floats
        musicVolume = PlayerPrefs.GetFloat("SettingsMusicVolume", 1);
        sfxVolume = PlayerPrefs.GetFloat("SettingsSFXVolume", 1);

        instance = this;
        DontDestroyOnLoad(instance);

        Change.Invoke(
            new bool[] { postProcessing, fullScreen, cameraShake, particles },
            new int[] { resolution, graphicsQuality },
            new float[] { musicVolume, sfxVolume }    
        );
    }

    public void Save() {
        // Booleans
        PlayerPrefs.SetInt("SettingsPostProcessing", postProcessing? 1 : 0);
        PlayerPrefs.SetInt("SettingsFullScreen", fullScreen? 1 : 0);
        PlayerPrefs.SetInt("SettingsCameraShake", cameraShake? 1 : 0);
        PlayerPrefs.SetInt("SettingsParticles", particles? 1 : 0);

        // Indexes
        PlayerPrefs.SetInt("SettingsResolution", resolution);
        PlayerPrefs.SetInt("SettingsGraphicsQuality", graphicsQuality);

        // Floats
        PlayerPrefs.SetFloat("SettingsMusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SettingsSFXVolume", sfxVolume);
        
        Change.Invoke(
            new bool[] { postProcessing, fullScreen, cameraShake, particles },
            new int[] { resolution, graphicsQuality },
            new float[] { musicVolume, sfxVolume }    
        );
    }
}