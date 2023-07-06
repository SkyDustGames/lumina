using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class SettingsUI : MonoBehaviour {

    [SerializeField] TMP_Dropdown resolution;
    [SerializeField] TMP_Dropdown graphicsQuality;
    [SerializeField] Slider music;
    [SerializeField] Slider sfx;
    [SerializeField] Toggle postProcessing;
    [SerializeField] Toggle fullScreen;
    [SerializeField] Toggle cameraShake;
    [SerializeField] Toggle particles;
    Resolution[] resolutions;

    private void Awake() {
        resolutions = Screen.resolutions;

        List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
        foreach (Resolution resolution in resolutions)
            list.Add(new TMP_Dropdown.OptionData(resolution.width + "x" + resolution.height));

        resolution.AddOptions(list);

        Settings.Change.AddListener((bools, ints, floats) => {
            postProcessing.isOn = bools[0];
            fullScreen.isOn = bools[1];
            cameraShake.isOn = bools[2];
            particles.isOn = bools[3];

            resolution.value = ints[0];
            graphicsQuality.value = ints[1];

            music.value = floats[0];
            sfx.value = floats[1];

            QualitySettings.SetQualityLevel(graphicsQuality.value);
            Screen.SetResolution(resolutions[resolution.value].width, resolutions[resolution.value].height, fullScreen.isOn);
        });
    }

    public void SetResolution(int index) {
        Settings.instance.resolution = index;
        Settings.instance.Save();
    }

    public void SetGraphicsQuality(int index) {
        Settings.instance.graphicsQuality = index;
        Settings.instance.Save();
    }

    public void SetMusic(float volume) {
        Settings.instance.musicVolume = volume;
        Settings.instance.Save();
    }

    public void SetSFX(float volume) {
        Settings.instance.sfxVolume = volume;
        Settings.instance.Save();
    }

    public void SetPostProcessing(bool value) {
        Settings.instance.postProcessing = value;
        Settings.instance.Save();
    }

    public void SetFullScreen(bool value) {
        Settings.instance.fullScreen = value;
        Settings.instance.Save();
    }

    public void SetCameraShake(bool value) {
        Settings.instance.cameraShake = value;
        Settings.instance.Save();
    }

    public void SetParticles(bool value) {
        Settings.instance.particles = value;
        Settings.instance.Save();
    }
}