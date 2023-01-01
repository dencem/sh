using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleclouds : MonoBehaviour
{
    private ParticleSystem particle;
    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        particle.Play();
        SoundManagerScript.PlaySound("land");
    }

}
