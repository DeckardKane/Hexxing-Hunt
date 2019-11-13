using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;

public class SeekerBehavior : MonoBehaviour
{

    public int playerId = 1;
    private Player player; // The Rewired Player
    private bool fire;

    Animator anim;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    public GameObject player1;
    public GameObject player2; //unnecessary?

    bool hitWitch = false;

    public MyScriptable gameStatus;
    public MyScriptable timer;
    public float shiftPenalty;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerId);
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2d.velocity.x == 0 && rb2d.velocity.y == 0) 
        {
            // if our velocity is 0, start playing idle animation!
            anim.enabled = true;
            anim.Play("Seeker Idle");
        } else
        {
            //check which direction we're going, this is checking to see if we're moving left
            if ( rb2d.velocity.x < 0)
            {
                spriteRenderer.flipX = true;
                    anim.Play("Seeker Walk");
            }
            // this else ends up checking for moving right
            else
            {
                spriteRenderer.flipX = false;
                anim.Play("Seeker Walk");
            }
        }

        GetInput();
        ProcessInput();

    }

    private void GetInput()
    {
        // Get the input from the Rewired Player. All controllers that the Player owns will contribute, so it doesn't matter
        // whether the input is coming from a joystick, the keyboard, mouse, or a custom controller.
        fire = player.GetButtonDown("Fire");
    }

    private void ProcessInput()
    {
        // Process fire
        if (fire && hitWitch == true)
        {
            gameStatus.Value = 2;
            print("You found the witch! You win!");
        } else if (fire && hitWitch != true)
        {
            // What if we made it so the timer decreased every time the hunter used the "declare witch" button?
            timer.Value = timer.Value - shiftPenalty;
            print("That wasn't the witch, dummy");
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == player1)
        {
            print("Hunter is colliding with witch");
            hitWitch = true;
        }
    }

    /*
    // We want to check if player2 has collided with player1's rigidbody. 
    // TO-DO: we could probably condense this to just OnCollisionStay2D?
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player1)
        {
            hitWitch = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject == player1)
        {
            hitWitch = false;
        }
    }
    */
}
