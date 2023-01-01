using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallscript : MonoBehaviour {

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("collide");
    }
}
