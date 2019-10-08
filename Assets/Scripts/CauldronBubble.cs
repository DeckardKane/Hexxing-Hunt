using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronBubble : MonoBehaviour
{

    public float bubbleDelay = 5f;
    float lastBubble;

    Animator anim;
    AudioSource audioSource;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        // Do the usual setup of retrieving other components in this game
        // object.

        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*anim.GetBool();
        if (time.now() - lastBubble >= bubbleDelay)
        {
            anim.SetBool("isBubble", true);
        }
        */
    }
}
