using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    // The name of the scene to go to.

    public string sceneName;

    // Update is called once per frame
    void Update()
    {
        // Despite the name of the property, this works on gamepad buttons too.

        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("Instructions");
        }
    }
}