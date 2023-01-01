using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

    public static AudioClip playerHitSound, smallCoinSound, bigCoinSound, landSound;
    static AudioSource audioSrc;


	// Use this for initialization
	void Start () {

        playerHitSound = Resources.Load<AudioClip>("death");
        smallCoinSound = Resources.Load<AudioClip>("coin");
        bigCoinSound = Resources.Load<AudioClip>("coinheart");
        landSound = Resources.Load<AudioClip>("land");
        audioSrc = GetComponent<AudioSource> ();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "death":
                audioSrc.PlayOneShot (playerHitSound);
                break;
            case "coin":
                audioSrc.PlayOneShot (smallCoinSound);
                break;
            case "coinheart":
                audioSrc.PlayOneShot (bigCoinSound);
                break;
            case "land":
                audioSrc.PlayOneShot(landSound);
                break;

        }
    }

}
