using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float horizontalInput = 0f;
    public float speed = 5f;
    public PlayerMovement movement;
    public bool isAlive = true;
    public Game_Manager manager;
    public Animator anim;
    public AudioSource audioS;
    public AudioClip coinSound;
    public AudioClip hurtSound;
    public AudioClip jumpSound;
    public AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Movement Code
        horizontalInput = Input.GetAxisRaw("Horizontal");
        //Jump Code
        if (Input.GetButtonDown("Jump") && isAlive == true)
        {
            if (movement.m_Grounded)
            {
                anim.SetTrigger("Jump");
                audioS.PlayOneShot(jumpSound, 1f);
            }
            movement.Jump();

        }

        //Set Animations
        anim.SetBool("Grounded", movement.m_Grounded);
        anim.SetBool("IsAlive", isAlive);

        if(horizontalInput == 0)
        {
            anim.speed = 1f;
            anim.SetBool("Move", false);
        }
        else
        {
            if(isAlive && movement.m_Grounded)
            {
                anim.speed = 1 * Mathf.Abs(horizontalInput);
            }
            anim.SetBool("Move", true);
        }






    }

    private void FixedUpdate()
    {
        if (isAlive == true) { 
        movement.Move(horizontalInput * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cherry")
        {
            Debug.Log("Cherry Picked!");
            Destroy(collision.gameObject);
            manager.totalCoins++;
            audioS.PlayOneShot(coinSound, 1f);
        }

        if(collision.gameObject.tag == "PoisonedCherry")
        {
            Debug.Log("You've been poisoned");
            Destroy(collision.gameObject);
            isAlive = false;
            audioS.PlayOneShot(hurtSound, 1f);
            anim.SetTrigger("Die");

        }
        if (collision.gameObject.tag == "Checkpoint")
        {
            Debug.Log("Checkpoint Passed!");
            manager.spawnPoint = collision.gameObject.transform;


        }
        if (collision.gameObject.tag == "LevelEnd")
        {
            manager.FinishLevel();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spikes" || collision.gameObject.tag == "Enemy")
        {
            if (isAlive)
            {
                isAlive = false;
                anim.SetTrigger("Die");
                audioS.PlayOneShot(hurtSound, 1f);
            }
        }

        if (collision.gameObject.tag == "WeakPoint")
        {
            collision.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(collision.transform.parent.gameObject);
            audioS.PlayOneShot(hitSound, 1f);
        }

    }

    public void Die()
    {
        manager.lives = 0;
        isAlive = false;
        anim.SetTrigger("Die");
        audioS.PlayOneShot(hurtSound, 1f);
    }


}
