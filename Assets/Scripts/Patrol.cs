using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    public float speed;
    public float distance;

    private bool movingUp = true;

    public Transform groundDetection;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == true)
        {
            if(movingUp == true)
            {
                transform.eulerAngles = new Vector3(-180, 0, 0);
                movingUp = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingUp = true;
            }
        }
    }

}
