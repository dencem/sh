using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    public int pointsToAdd;
    private ParticleSystem particle;

    void Start()
    {
    }

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.GetComponent<Player>() == null)
            return;
        SoundManagerScript.PlaySound("coin");



        ScoreManager.AddPoints(pointsToAdd);

        Destroy(gameObject);

    }

}
