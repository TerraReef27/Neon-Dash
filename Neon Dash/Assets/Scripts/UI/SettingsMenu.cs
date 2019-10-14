using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] Slider masterVolume = null;
    [SerializeField] Slider musicVolume = null;
    [SerializeField] Slider sfxVolume = null;

    [SerializeField] private GameObject menu = null;
    [SerializeField] private GameObject settings = null;

    private AudioHandler AH;

    private void Awake()
    {
        AH = FindObjectOfType<AudioHandler>();
    }
    private void Start()
    {
        masterVolume.value = PlayerPrefs.GetFloat("MasterVolume");
        musicVolume.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxVolume.value = PlayerPrefs.GetFloat("SfxVolume");
        StartCoroutine(GetManagers());
    }

    IEnumerator GetManagers()
    {
        yield return new WaitForSeconds(.1f);
        AH = FindObjectOfType<AudioHandler>();
    }

    public void SetMasterVolume()
    {
        AH.SetMixerLevel("masterVolume", masterVolume.value);
    }
    public void SetMusicVolume()
    {
        AH.SetMixerLevel("musicVolume", musicVolume.value);
    }
    public void SetSFXVolume()
    {
        AH.SetMixerLevel("sfxVolume", sfxVolume.value);
    }

    public void OnCalibrateButtonClick()
    {
        PlayClickSound();
        PlayerPrefs.SetFloat("MasterVolume", masterVolume.value);
        PlayerPrefs.SetFloat("SfxVolume", musicVolume.value);
        PlayerPrefs.SetFloat("MusicVolume", sfxVolume.value);
        SceneManager.LoadScene(2);
    }

    public void OnBackButtonClick()
    {
        PlayClickSound();
        PlayerPrefs.SetFloat("MasterVolume", masterVolume.value);
        PlayerPrefs.SetFloat("SfxVolume", musicVolume.value);
        PlayerPrefs.SetFloat("MusicVolume", sfxVolume.value);
        menu.SetActive(true);
        settings.SetActive(false);
    }

    void PlayClickSound()
    {
        AH.PlaySound("Button");
    }
}
