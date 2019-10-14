using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem dashParticles = null;

    public void PlayDashParticles(Vector2 direction)
    {
        //dashParticles.transform.position
        dashParticles.Play();
    }
}
