using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_Spin : MonoBehaviour
{
    [SerializeField] float spinSpeed = .1f; //make it so it gets faster as level gets harder
    [SerializeField] bool spinClockwise = true;

    void Start()
    {
        spinSpeed = FindObjectOfType<GameManager>().levelSpeed * spinSpeed;
        if(Random.value >= .5)
        {
            spinClockwise = false;
        }
    }

    void Update()
    {
        if(spinClockwise)
        {
            transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.forward * -spinSpeed * Time.deltaTime);
        }
    }
}
