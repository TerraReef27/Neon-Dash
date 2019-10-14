using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMover : MonoBehaviour
{
    GameManager gm;
    public bool hasBeenScored = false;

    public float obstacleDifficulty = 50f; //Not well Organized
    [SerializeField] private BuildingPart[] subParts = null;

    private GameObject player;
    private SpriteRenderer sr;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        sr = GetComponent<SpriteRenderer>();

        if(gm.state == GameManager.playerState.Alive)
        {
            player = FindObjectOfType<PlayerController>().gameObject;
        }
    }
    
    void Update()
    {
        if(gm.isFasterSpeed)
        {
            transform.position -= (Vector3.right * gm.fasterLevelSpeed * Time.deltaTime);
        }
        else
        {
            transform.position -= (Vector3.right * gm.levelSpeed * Time.deltaTime);
        }
        
        if(player != null)
        {
            if (!hasBeenScored)
            {
                if (player.transform.position.x > gameObject.transform.position.x)
                {
                    GotScore();
                }
            }
        }
    }

    public void GotScore()
    {
        hasBeenScored = true;
        gm.IncrementCurrentScore();
    }

    public void SetColor(Color[] newColors, int startOfColors)
    {
        foreach(BuildingPart sub in subParts)
        {
            for(int i = 0; i < 3; i++)
            {
                sub.SetColorOfPart(i, newColors[i + startOfColors]);
            }
        }
    }
}
