using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPatrol : MonoBehaviour {

    public float speed;
    public float distance;

    private bool movingRight = true;
    private bool moving;
    [SerializeField]
    private Vector3 velocity;

    public Transform groundDetection;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.left, distance);
        if (groundInfo.collider == true)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            moving = true;
            other.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.collider.transform.SetParent(null);
        }
    }

    void FixedUpdate()
    {
        if (moving)
        {
            transform.position += (velocity * Time.deltaTime);
        }

    }
}
