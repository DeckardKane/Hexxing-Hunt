using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowsPlayer1 : MonoBehaviour
{
	public GameObject player;
	public GameObject ActiveCam;

    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.Find("Witch");
		ActiveCam = GameObject.Find("P1Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > -8 && player.transform.position.x < -5.375f)
		{
            if(player.transform.position.y > 1 && player.transform.position.y < 3.5f)
			{
				ActiveCam.transform.position = new Vector3(-6.6f, 2.2f, -10f);
			}
			if (player.transform.position.y > 3.5f && player.transform.position.y < 4f)
			{
				ActiveCam.transform.position = new Vector3(-6.6f, 5f, -10f);
			}
		}
    }
}
