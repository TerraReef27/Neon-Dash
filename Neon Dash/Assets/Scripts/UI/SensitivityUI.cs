using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SensitivityUI : MonoBehaviour
{
    [SerializeField] private Slider sensitivitySlider = null;

    private PlayerController pc;
    private AudioHandler AH;

    void Awake()
    {
        pc = FindObjectOfType<PlayerController>();
        AH = FindObjectOfType<AudioHandler>();
    }
    
    void Start()
    {
        sensitivitySlider.value = pc.speed;
        StartCoroutine(GetManagers());
    }

    IEnumerator GetManagers()
    {
        yield return new WaitForSeconds(.1f);
        AH = FindObjectOfType<AudioHandler>();
    }

    public void OnSenstivitySliderChange()
    {
        pc.speed = sensitivitySlider.value;
    }

    public void OnBackButtonClick()
    {
        PlayClickSound();
        PlayerPrefs.SetFloat("PlayerSensitivity", sensitivitySlider.value);
        SceneManager.LoadScene(0);
    }

    void PlayClickSound()
    {
        AH.PlaySound("Button");
    }
}
