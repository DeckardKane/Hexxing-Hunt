using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{

    public MyScriptable gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus.Value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStatus.Value != 0)
        {
            print("Welp, someone won, switch to game over scene!");
            SceneManager.LoadScene("GameOver");
        }
    }
}
