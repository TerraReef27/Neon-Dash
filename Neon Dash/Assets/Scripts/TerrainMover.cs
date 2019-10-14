using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMover : MonoBehaviour
{
    [SerializeField] float period = 2f;
    [SerializeField] Vector3 movementVector = Vector3.zero;
    [SerializeField] [Range(-1, 1)] float movementFactor;

    Vector3 startingPosition;

    // Use this for initialization
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period; //gets larger from 0
        const float tau = Mathf.PI * 2f; //complete circle (6.2)
        float rawSinWave = Mathf.Sin(cycles * tau); //goes from -1 to 1

        movementFactor = rawSinWave / 2f + .5f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
