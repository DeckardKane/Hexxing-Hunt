using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a new using statement. We need this whenever we are working with UI
// elements in a behavior.

using UnityEngine.UI;

public class CountsDown : MonoBehaviour
{
    // How many seconds are left in the timer.
    public float timeLeft = 10f;

    // References to the game objects we manage. The game objects are public so
    // that we can set them in the Unity editor, but we also need a reference to
    // their Text and RectTransform properties. I named these properties
    // [name of game object][name of component].
    //
    // Note that UI elements use a RectTranform, not the usual Transform we have
    // been using so far.

    public GameObject textObject;
    public GameObject meterObject;
    Text textTextComponent;
    RectTransform meterRectComponent;

    // We need to remember how much time we had left originally, and how wide
    // the meter image was originally as well. 

    float startTimeLeft;
    float startMeterWidth;

    public MyScriptable gameStatus;
    public MyScriptable timer;

    // Start is called before the first frame update
    void Start()
    {
        timer.Value = 120f;

        // You've seen these calls before, but before we were getting a
        // component belonging to the game object the behavior was attached to.
        // In this case, we're instead getting components on another object.

        textTextComponent = textObject.GetComponent<Text>();
        meterRectComponent = meterObject.GetComponent<RectTransform>();


        // Record the starting time left and the meter width so that we can
        // update the meter width in Update() below.

        //startTimeLeft = timeLeft;
        startTimeLeft = timer.Value;
        startMeterWidth = meterRectComponent.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime records how many seconds elapsed since the last
        // Update() call.

        timer.Value = timer.Value - Time.deltaTime;
        //print(timer.Value);


        if (timer.Value < 0f)
        {
            timer.Value = 0f;
        }

        if (timer.Value > 300f)
        {
            timer.Value = 300f;
        }

        // Update the text component. 
        textTextComponent.text = "Time left: " + timer.Value.ToString("#.00");

        // Change the width of the meter.
        float timePercentLeft = timer.Value / startTimeLeft;

        meterRectComponent.sizeDelta = new Vector2(
            startMeterWidth * timePercentLeft,
            meterRectComponent.rect.height
        );

        if (timer.Value <= 0f)
        {
            print("Timer has hit zero!");
            Debug.Log("Name: " + gameStatus.name + "; Value: " + gameStatus.Value);
            gameStatus.Value = 1;
        }
    }

    public void AddTime(float time)
    {
        timer.Value = timer.Value + time;
    }
}
