// PlayerMove
// By Lex King
// Place onto Main Player
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class PlayerMove : MonoBehaviour
/*
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer PlayerSprite;
    AudioSource pickupAudioSource;
    AudioSource jumpAudio;

    public float speed;
    public int jumpForce;
    public int bounceForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

    public AudioClip jumpSFX;
    public AudioMixerGroup audioMixer;

    bool coroutineRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        PlayerSprite = GetComponent<SpriteRenderer>();
        pickupAudioSource = GetComponent<AudioSource>();

        if (speed <= 0)
        {
            speed = 5.0f;
        }

        if (jumpForce <= 0)
        {
            jumpForce = 300;
        }

        if (bounceForce <= 0)
        {
            bounceForce = 300;
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
        }

        if (!groundCheck)
        {
            Debug.Log("Groundcheck does not exist, please assign a ground check object");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce);

                if (!jumpAudio)
                {
                    jumpAudio = gameObject.AddComponent<AudioSource>();
                    jumpAudio.clip = jumpSFX;
                    jumpAudio.outputAudioMixerGroup = audioMixer;
                    jumpAudio.loop = false;
                }

                jumpAudio.Play();
            }

            Vector2 moveDirection = new Vector2(horizontalInput * speed, rb.velocity.y);
            rb.velocity = moveDirection;

            anim.SetFloat("speed", Mathf.Abs(horizontalInput));
            anim.SetBool("isGrounded", isGrounded);

            if (PlayerSprite.flipX && horizontalInput > 0 || !PlayerSprite.flipX && horizontalInput < 0)
                PlayerSprite.flipX = !PlayerSprite.flipX;
        }
    }

// cut start
    public void StartJumpForceChange()
    {
        if (!coroutineRunning)
        {
            StartCoroutine("JumpForceChange");
        }
        else
        {
            StopCoroutine("JumpForceChange");
            StartCoroutine("JumpForceChange");
        }
    }

    IEnumerator JumpForceChange()
    {
        coroutineRunning = true;
        jumpForce = 600;
        yield return new WaitForSeconds(10.0f);
        jumpForce = 300;
        coroutineRunning = false;
    }
//Cut end

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Squish")
        {
            if (!isGrounded)
            {
                collision.gameObject.GetComponentInParent<EnemyWalker>().IsSquished();
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * bounceForce);
            }
        }
    }

    public void CollectibleSound(AudioClip pickupAudio)
    {
        pickupAudioSource.clip = pickupAudio;
        pickupAudioSource.Play();
    }
}
//End of starter Script
*/
//Start of New script
{
    public float speed = 3f;
    bool isMoving = false;
    bool walk_up;
    bool walk_down;
    bool walk_left;
    bool walk_right;
    public Rigidbody2D rb;
    Animator anim;
    SpriteRenderer marioSprite;
    AudioSource pickupAudioSource;
    AudioSource jumpAudioSource;
    public AudioClip jumpSFX;
    public AudioMixerGroup audioMixer;
    Vector2 movement;
    private void Update() //Handle Input inside Update() and movement physics inside FixedUpdate().
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
            speed = 3f;
            walk_up = true;
        }
    //End Update()
    }
    private void FixedUpdate() //Use FixedUpdate for Physics as it calls 50 times a second; much better for frame rate issues.
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void CollectibleSound(AudioClip pickupAudio)
    {
        pickupAudioSource.clip = pickupAudio;
        pickupAudioSource.Play();
    }
}
