using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    CircleCollider2D myCollider;
    GameManager gm;
    GameUI UI;

    // Start is called before the first frame update
    void Awake()
    {
        myCollider = GetComponent<CircleCollider2D>();
        gm = FindObjectOfType<GameManager>();
        UI = FindObjectOfType<GameUI>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "killer")
        {
            Destroy(gameObject);
            gm.UpdateHighScore();
            UI.SwitchToDeath();
            gm.Die();
        }
    }
}
