using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevControls : MonoBehaviour
{
    [SerializeField] GameObject player = null;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(player);
            print("Spawned new player");
        }
    }
}
