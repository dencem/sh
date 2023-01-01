using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const bool V = true;
    private Rigidbody2D myRigidbody;

    private Animator myAnimator;
    private bool alreadyPlayed;
    [SerializeField]
    private float movementSpeed;

    private bool facingRight;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    private bool isGrounded;

    private bool jump;

    [SerializeField]
    private bool airControl;

    [SerializeField]
    private float jumpForce;

    public GameObject player;

    Player playerCtrl;

    private bool moving;

    [SerializeField]
    private Vector3 velocity;

    public static AudioClip jumpSound;
    static AudioSource audioSrc;

    public ParticleSystem dust;



    // Use this for initialization
    void Start()
    {
        playerCtrl = GetComponentInParent<Player>();
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        alreadyPlayed = false;
        jumpSound = Resources.Load<AudioClip>("jump");
        audioSrc = GetComponent<AudioSource>();
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

    // Update is called once per frame
    void FixedUpdate()

    {
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);

        Flip(horizontal);

        HandleLayers();

        if (moving)
        {
            transform.position += (velocity * Time.deltaTime);
        }

        isGrounded = IsGrounded();
        ResetValues();

        HandleInput();
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                CreateDust();
                jump = true;
            }
        }

        if (Input.GetKey(KeyCode.JoystickButton0))
        {
            if (isGrounded)
            {
                CreateDust();
                jump = true;
            }
        }

        if (isGrounded && jump && !alreadyPlayed)
        {
            alreadyPlayed = true;
        }

        else
        {
            alreadyPlayed = false;
        }

        if (alreadyPlayed && isGrounded && myRigidbody.velocity.y < 0)
        {
            alreadyPlayed = false;
        }

        if (alreadyPlayed)
        {
            audioSrc.PlayOneShot(jumpSound);
        }
    }

    private void HandleMovement(float horizontal)
    {
        if (myRigidbody.velocity.y < 0)
        {
            myAnimator.SetBool("land", true);
        }
        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);

        if (isGrounded && jump)
        {
            myRigidbody.AddForce(new Vector2(0, jumpForce));
            myAnimator.SetTrigger("jump");
        }

        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void HandleInput()
    {
        
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

    private void ResetValues()
    {
        jump = false;
    }

    private bool IsGrounded()
    {
        if (myRigidbody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        myAnimator.ResetTrigger("jump");
                        myAnimator.SetBool("land", false);
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void HandleLayers()
    {
        if (!isGrounded)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }
    }

    void OnCollisionEnter2D (Collision other)
    {
        if(other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    void OnCollisionExit2D(Collision other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    void OnCollisionEnter2D(Collider other)
    {
        if(other.transform.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collider other)
    {
        if(other.transform.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    void CreateDust()
    {
        dust.Play();
    }
}
