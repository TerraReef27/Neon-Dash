using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    public float levelSpeed = 10f;
    private float startSpeed;
    public float fasterLevelSpeed;
    public bool isFasterSpeed = false;

    [SerializeField] int logSpeedMultiplyer = 10;

    public int currentScore = 0; /* Will need to implement a save score system */
    string highScorePref = "HighScore";

    private GameUI UI;
    private AudioHandler AH;

    public enum playerState { Alive, Paused, Dead }
    public playerState state = playerState.Alive;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        
        AH = FindObjectOfType<AudioHandler>();
    }

    void Start()
    {
        startSpeed = levelSpeed;
        isFasterSpeed = false;
        Reset();
    }

    /// <summary>
    /// Multiplies level speed by the inputed multiplyer
    /// </summary>
    /// <param name="speedMultiplyer">Number to multiply speed byS</param>
    public void ChangeLevelSpeed(float speedMultiplyer)
    {
        if(!isFasterSpeed)
        {
            isFasterSpeed = true;
        }
        fasterLevelSpeed = levelSpeed + speedMultiplyer;
        //oldLevelSpeed = levelSpeed;
        //levelSpeed *= speedMultiplyer;
    }

    public void ReturnToOldLevelSpeed()
    {
        isFasterSpeed = false;
    }

    public void IncrementCurrentScore()
    {
        currentScore++;

        if(UI != null)
        {
            UI.UpdateScoreVisual();
        }
        else
        {
            UI = FindObjectOfType<GameUI>();
            UI.UpdateScoreVisual();
        }

        UpdateLevelSpeed();
        AH.PlaySound("Point");
    }

    void UpdateLevelSpeed()
    {
        if(currentScore > 1)
        {
            levelSpeed = (Mathf.Log(currentScore / 2) * logSpeedMultiplyer + 10);
        }
    }

    public void Reset()
    {
        currentScore = 0;
        levelSpeed = startSpeed;
        state = playerState.Alive;
        Time.timeScale = 1f;
    }

    public void Die()
    {
        state = playerState.Dead;
        Time.timeScale = 0f;
    }

    public void UpdateHighScore()
    {
        if(currentScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }
}
