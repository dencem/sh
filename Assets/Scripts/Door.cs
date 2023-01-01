using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Door : MonoBehaviour {

    public int LevelToLoad;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
#pragma warning disable CS0618 // Typ oder Element ist veraltet
            Application.LoadLevel(LevelToLoad);
#pragma warning restore CS0618 // Typ oder Element ist veraltet
        }
    }
}
