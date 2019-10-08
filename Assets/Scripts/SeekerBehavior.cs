using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeekerBehavior : MonoBehaviour
{
    Animator anim;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    public GameObject player1;
    public GameObject player2; //unnecessary?

    private int shiftUses;
    public string sceneName;
    bool hitWitch = false;
    public bool noShiftUses;
    public bool foundWitch = false;

    // Start is called before the first frame update
    void Start()
    {
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

        if (Input.GetKeyDown(KeyCode.RightShift) && hitWitch == true) // If right shift is pushed down AND we are colliding with the witch
        {
            foundWitch = true;
            print("You found the witch! You win!");
        } else if (Input.GetKeyDown(KeyCode.RightShift))
        {
            shiftUses++;
            if(shiftUses > 3f) // why is it 3f (f is for floats) if we're using an int for shiftUses?
            {
                noShiftUses = true; 
                SceneManager.LoadScene(sceneName);
            }
            print("That wasn't the witch, dummy");
        }
    }
    
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

}
