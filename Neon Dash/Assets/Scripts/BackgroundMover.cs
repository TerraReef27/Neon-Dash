using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    GameManager gm;
    Renderer myRenderer;
    [SerializeField] float rateLessThanSpeed = .5f;

    float currentSpeed = 0f;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        myRenderer = GetComponent<Renderer>();
    }
    
    void Update()
    {
        if(!gm.isFasterSpeed)
        {
            currentSpeed = gm.levelSpeed * rateLessThanSpeed;
        }
        else
        {
            currentSpeed = gm.fasterLevelSpeed * rateLessThanSpeed;
        }
        

        float offset = Time.time * currentSpeed;

        float offsetAdd = (currentSpeed * Time.fixedDeltaTime) / 2;
        float currentOffset = myRenderer.material.GetTextureOffset("_MainTex").x;

        myRenderer.material.SetTextureOffset("_MainTex", new Vector2(offsetAdd + currentOffset, 0));
    }
}
