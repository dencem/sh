﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textvanish : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {

        Destroy(gameObject);


    
    }
}