using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCenter : MonoBehaviour
{
    GameManager gm;
    PlayerController player;
    public bool playerInPushZone = false;
    public float pushbackRate = 10f;

    private float pusherPosX;
    private float playerDifference;


    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerController>();

        pusherPosX = gameObject.transform.position.x;
    }

    void Start()
    {
        playerDifference = 0f;
    }

    void Update()
    {
        if(player != null)
        {
            playerDifference = player.gameObject.transform.position.x - pusherPosX;
            if(playerDifference > 0)
            {
                //float rate = Mathf.Exp(playerDifference/pushbackRate);
                float rate = playerDifference * pushbackRate;
                player.PushBackPlayer(pusherPosX, rate);
                gm.ChangeLevelSpeed(rate);
                playerInPushZone = true;
            }
            else
            {
                gm.ReturnToOldLevelSpeed();
                playerInPushZone = false;
            }
        }
    }

    /**
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(!playerInPushZone)
            {
                playerInPushZone = true;
            }
            
            gm.ChangeLevelSpeed(pushbackSpeed);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(playerInPushZone)
            {
                playerInPushZone = false;
            }
            
            gm.ReturnToOldLevelSpeed();
        }
    }
    **/
}
