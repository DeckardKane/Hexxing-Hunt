using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class RewiredInputListener : MonoBehaviour
{
    // The Rewired player id of this character
    public int playerId;

    // The movement speed of this character
    public float moveSpeed = 3.0f;

    private Player player; // The Rewired Player
    //private CharacterController cc;
    private Rigidbody2D rb2d;
    private Vector3 moveVector;
    private bool fire;

    void Awake()
    {
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        player = ReInput.players.GetPlayer(playerId);

        // Get the character controller
        //cc = GetComponent<CharacterController>();
        rb2d = GetComponent<Rigidbody2D>();

    }

    /*
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("P" + playerId + "Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("P" + playerId + "Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * moveSpeed);
    }
    */

    
    void Update()
    {
        GetInput();
        ProcessInput();
    }

    private void GetInput()
    {
        // Get the input from the Rewired Player. All controllers that the Player owns will contribute, so it doesn't matter
        // whether the input is coming from a joystick, the keyboard, mouse, or a custom controller.

        moveVector.x = player.GetAxis("Move Horizontal"); // get input by name or action id
        moveVector.y = player.GetAxis("Move Vertical");
        fire = player.GetButtonDown("Fire");
    }

    private void ProcessInput()
    {
        // Process movement
        if (moveVector.x != 0.0f || moveVector.y != 0.0f)
        {
            print("Player " + playerId + " is moving");
            //cc.Move(moveVector * moveSpeed * Time.deltaTime);
            rb2d.AddForce(moveVector * moveSpeed); // they include * Time.deltaTime, but why and does it help us?
        }

        // Process fire
        if (fire)
        {
            print("Fire away!");
        }
    }
    
}
