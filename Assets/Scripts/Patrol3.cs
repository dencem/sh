using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol3 : MonoBehaviour {

    public float speed;
    public float distance;

    private bool movingLeft = true;

    public Transform groundDetection;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, distance);
        if (groundInfo.collider == true)
        {
            if (movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }
    }

}
