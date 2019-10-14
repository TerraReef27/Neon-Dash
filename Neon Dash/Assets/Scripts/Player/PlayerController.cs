using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 startTouch;
    private Vector2 endTouch;

    public float speed = 10f;

    [Tooltip("Speed at which the player is pushed back into the ok zone")]
    public float pushBackSpeed = 1f;

    Rigidbody2D myRigidbody;
    VFXHandler fx;
    AudioHandler AH;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        fx = FindObjectOfType<VFXHandler>();
        AH = FindObjectOfType<AudioHandler>();
        Debug.Log(AH.gameObject.GetInstanceID());   
    }

    private void Start()
    {
        speed = PlayerPrefs.GetFloat("PlayerSensitivity");
        StartCoroutine(GetManagers());
    }

    IEnumerator GetManagers()
    {
        yield return new WaitForSeconds(.1f);
        AH = FindObjectOfType<AudioHandler>();
        Debug.Log(AH.gameObject.GetInstanceID());
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouch = touch.position;
                    break;

                case TouchPhase.Ended:
                    endTouch = touch.position;

                    myRigidbody.velocity = Vector2.zero;

                    Vector2 direction = endTouch - startTouch;

                    myRigidbody.AddForce(direction * speed);

                    fx.PlayDashParticles(direction); //plays the dash particles in the direction of the dash
                    
                    AH.PlaySound("Whoosh");
                    break;
            }
        }
    }

    void FixedUpdate()
    {
            
    }

    public void PushBackPlayer(float pointToPushTo, float pushSpeed)
    {
        myRigidbody.AddForce(Vector2.left * pushSpeed * pushBackSpeed);
    }
}
