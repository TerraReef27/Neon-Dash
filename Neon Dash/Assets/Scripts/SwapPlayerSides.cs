using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPlayerSides : MonoBehaviour
{
    [SerializeField] private float swapLocation = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SwapSides(collision.gameObject);
        }
    }

    private void SwapSides(GameObject player)
    {
        Vector3 currentLocation = player.transform.position;
        currentLocation.y = swapLocation;
        player.transform.position = currentLocation;
    }
}
