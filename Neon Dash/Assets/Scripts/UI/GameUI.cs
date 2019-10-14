using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText = null;
    [SerializeField] TextMeshProUGUI highScoreText = null;
    [SerializeField] TextMeshProUGUI deadScore = null;

    [SerializeField] GameObject[] menus = null;
    private int currentMenu = 0;

    AudioHandler AH;

    private void Awake()
    {
        AH = FindObjectOfType<AudioHandler>();
    }
    void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        StartCoroutine(GetManagers());
    }

    IEnumerator GetManagers()
    {
        yield return new WaitForSeconds(.1f);
        AH = FindObjectOfType<AudioHandler>();  
    }

    public void UpdateScoreVisual()
    {
        scoreText.text = FindObjectOfType<GameManager>().currentScore.ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void SwitchToDeath()
    {
        menus[currentMenu].SetActive(false);
        menus[2].SetActive(true);
        currentMenu = 2;

        deadScore.text = FindObjectOfType<GameManager>().currentScore.ToString();
    }

    public void OnPlayButtonClick()
    {
        PlayButtonSound();
        SceneManager.LoadScene(1);
        FindObjectOfType<GameManager>().Reset();
    }

    public void OnMenuButtonClick()
    {
        PlayButtonSound();
        SceneManager.LoadScene(0);
        FindObjectOfType<GameManager>().Reset();
    }

    void PlayButtonSound()
    {
        AH.PlaySound("Button");
    }
}
