using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float setTimer = 5f;

    public GameObject textObject;
    Text textTextComponent;


    // Start is called before the first frame update
    void Start()
    {

        player1 = GameObject.Find("Witch");
        player2 = GameObject.Find("Seeker");

    }

    // Update is called once per frame
    void Update()
    {

        // check if seeker has found witch!
        if (player2.GetComponent<SeekerBehavior>().foundWitch == true)
        {
            SceneManager.LoadScene("Gameover");
        }

        //if the currenttime is equal zero
        if (setTimer <= 0)

        {
            // currenttime is zero
            setTimer = 0;

            //player of value wil be destroy and return to first scene 
            Destroy(player1);

            SceneManager.LoadScene("Gameover");

        }

        else
        {
            // print("lets get stRTED"); print statements like this can be useful, but often clog up the console!
            //currentttime will get minus each time in the scene
            setTimer -= Time.deltaTime;
            // print(setTimer);

        }

    }
}
