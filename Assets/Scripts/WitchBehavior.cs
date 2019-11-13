using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class WitchBehavior : MonoBehaviour
{

    public int playerId = 0;
    private Player player; // The Rewired Player
    private bool fire;

    Animator anim;
    public AudioSource notaudio;
    public AudioClip audioclip;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;
    public Sprite sprite10;
    public Sprite sprite11;
    public Sprite sprite12;
    public Sprite sprite13;
    public Sprite sprite14;

    private int propNumber = 0;

    // Start is called before the first frame update
    void Start()
    {

        player = ReInput.players.GetPlayer(playerId);

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        rb2d = GetComponent<Rigidbody2D>();
        notaudio = GetComponent<AudioSource>();
        audioclip = GetComponent<AudioClip>();
 
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = sprite1; // set the sprite to sprite1

    }

    // Update is called once per frame
    void Update()
    {
        if (rb2d.velocity.x == 0 && rb2d.velocity.y == 0 && propNumber == 0)
        {
            //anim.SetBool("isIdle", true);
            anim.enabled = true;
            anim.Play("idle");
            //print("Witch not moving, play idle animation!");
            //print(rb2d.velocity);
        } else
        {
            //anim.SetBool("isIdle", false);
            //anim.enabled = false;
            //print("Witch is moving, stop playing idle animation!");
            //print(rb2d.velocity);

            if (rb2d.velocity.x < 0 && propNumber == 0)
            {
                spriteRenderer.flipX = true;
                anim.Play("walkRight");
            }
            else if (rb2d.velocity.x > 0 && propNumber == 0)
            {
                spriteRenderer.flipX = false;
                anim.Play("walkRight");
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
        if (fire)
        {
            ChangeAppearance();
        }
    }

    void ChangeAppearance()
    {

        // Essentially, every time spacebar is pressed, we want to make the propNumber go up.
        // We also want it to cycle around back to 0 after reaching 13, as opposed to just going up
        // endlessly. So this if statement checks the propNumber, and either iterates it by one 
        // if less than 13, or resets to 0 if 13.
        // Remember that we start at 0! This is important because the max propNumber will always be 
        // one less than the largest sprite number (for instance, sprite14).
        if (propNumber < 13)
        {
            propNumber++;
        }
        else
        {
            propNumber = 0;
        }

        // Now that we have properly set our propNumber, use it to change the witch sprite.
        if (propNumber == 0)
        {
            spriteRenderer.sprite = sprite1; // this is our default witch sprite
            anim.enabled = true;
        }
        else if (propNumber == 1)
        {
            spriteRenderer.sprite = sprite2; // these can be set as needed!
            anim.enabled = false;
        }
        else if (propNumber == 2)
        {
            spriteRenderer.sprite = sprite3;
            anim.enabled = false;
        }
        else if (propNumber == 3)
        {
            spriteRenderer.sprite = sprite4;
            anim.enabled = false;
        }
        else if (propNumber == 4)
        {
            spriteRenderer.sprite = sprite5;
            anim.enabled = false;
        }
        else if (propNumber == 5)
        {
            spriteRenderer.sprite = sprite6;
            anim.enabled = false;
        }
        else if (propNumber == 6)
        {
            spriteRenderer.sprite = sprite7; // this is our default witch sprite
            anim.enabled = false;
        }
        else if (propNumber == 7)
        {
            spriteRenderer.sprite = sprite8; // these can be set as needed!
            anim.enabled = false;
        }
        else if (propNumber == 8)
        {
            spriteRenderer.sprite = sprite9;
            anim.enabled = false;
        }
        else if (propNumber == 9)
        {
            spriteRenderer.sprite = sprite10;
            anim.enabled = false;
        }
        else if (propNumber == 10)
        {
            spriteRenderer.sprite = sprite11;
            anim.enabled = false;
        }
        else if (propNumber == 11)
        {
            spriteRenderer.sprite = sprite12;
            anim.enabled = false;
        }
        else if (propNumber == 12)
        {
            spriteRenderer.sprite = sprite13; // this is our default witch sprite
            anim.enabled = false;
        }
        else if (propNumber == 13)
        {
            spriteRenderer.sprite = sprite14; // these can be set as needed!
            anim.enabled = false;
        }
    }
}
