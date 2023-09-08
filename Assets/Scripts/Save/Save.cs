using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class Save {
    
    public List<string> unlockedPlanets = new() { "Lumina" };
    public string nextPlanet = "Lumina";
    public int timesPlayed = 0;

    // SETTINGS
    public bool postProcessing = true;
    public bool fullscreen = true;
    public bool cameraShake = true;
    public bool particles = true;
    public int resolutionIndex = Array.IndexOf(Screen.resolutions, Screen.currentResolution);
    public int graphicsQuality = QualitySettings.GetQualityLevel();
    public float musicVolume = 1f;
    public float sfxVolume = 1f;
}