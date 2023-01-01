using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    private ParticleSystem particle;
    private SpriteRenderer sr;
    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        StartCoroutine(Break());

 
    }

    private IEnumerator Break()
    {
        particle.Play();


        sr.enabled = false;

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}

