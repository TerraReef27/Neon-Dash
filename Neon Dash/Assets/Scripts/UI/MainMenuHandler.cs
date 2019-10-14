using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] GameObject mainMenu = null;
    [SerializeField] GameObject settingsMenu = null;
    [SerializeField] GameObject helpMenu = null;

    AudioHandler AH;

    private void Awake()
    {
        AH = FindObjectOfType<AudioHandler>();
        StartCoroutine(GetManagers());
    }

    IEnumerator GetManagers()
    {
        yield return new WaitForSeconds(.1f);
        AH = FindObjectOfType<AudioHandler>();
    }

    public void OnPlayButtonClick()
    {
        PlayClickSound();
        SceneManager.LoadScene(1);
        FindObjectOfType<GameManager>().Reset();
    }

    public void OnSettingsButtonClick()
    {
        PlayClickSound();
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void OnBackButtonClick()
    {
        PlayClickSound();
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void OnHelpButtonClick()
    {
        PlayClickSound();
        mainMenu.SetActive(false);
        helpMenu.SetActive(true);
    }
    public void OnHelpBackButtonClick()
    {
        PlayClickSound();
        mainMenu.SetActive(true);
        helpMenu.SetActive(false);
    }

    void PlayClickSound()
    {
        AH.PlaySound("Button");
    }
}
