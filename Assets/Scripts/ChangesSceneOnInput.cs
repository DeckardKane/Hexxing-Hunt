using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangesSceneOnInput : MonoBehaviour
{
	// The name of the scene to go to.

	public string sceneName;
    public float delayLeft = 2f;
    public bool timeOut = false;
    public float timeLeft = 5f;
    public bool timeOutAltScene = false;
    public string timeOutSceneName;

    float startDelayLeft;
    float startTimeLeft;

    private void Start()
    {
        startDelayLeft = delayLeft;
        startTimeLeft = timeLeft;
    }

    // Update is called once per frame
    void Update()
	{

        delayLeft = delayLeft - Time.deltaTime;
        timeLeft = timeLeft - Time.deltaTime;

        if (timeLeft < 0)
        {
            timeLeft = 0;
        }

        // Despite the name of the property, this works on gamepad buttons too.

        if (Input.anyKeyDown && delayLeft <= 0f)
		{
            print("Input received, prepare to switch...");
            print("Switching to first choice scene: " + sceneName);
            SceneManager.LoadScene(sceneName);
		} else if (timeOut && timeLeft <= 0f)
        {
            print("Time has run out...");
            if (timeOutAltScene == false)
            {
                print("Switching to first choice scene: " + sceneName);
                SceneManager.LoadScene(sceneName);
            } else
            {
                print("Switching to alternate scene: " + timeOutSceneName);
                SceneManager.LoadScene(timeOutSceneName);
            }
        }
	}
}
