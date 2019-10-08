using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCamera : MonoBehaviour
{

    GameObject witch;
    GameObject activeCam;

    Collider2D box;
    Vector3 boxCenter;

    // Start is called before the first frame update
    void Start()
    {
        witch = GameObject.Find("Witch");
        activeCam = GameObject.Find("P1Camera");

        box = GetComponent<Collider2D>();
        //Fetch the center of the Collider volume
        boxCenter = box.bounds.center;
    }

    // this function is called every frame where the gameobject has another gameobject inside its bounds (the gameobjects
    // are set to behave as triggers in this case)
    private void OnTriggerStay2D(Collider2D other)
    {
        // and when it's called, we check to see if the colliding object is the witch...
        if (other.gameObject == witch)
        {
            // if it is, we move the camera to position (in this case, the center of the Collider volume)
            activeCam.transform.position = new Vector3(boxCenter.x, boxCenter.y, -10f);
        }
    }
}
