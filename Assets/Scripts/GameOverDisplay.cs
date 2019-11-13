using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour
{
    public GameObject winOrLoseDisplay;
    Text textTextComponent;

    public MyScriptable gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        textTextComponent = winOrLoseDisplay.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStatus.Value == 1)
        {
            print("The witch has survived! Hunter loses.");
            textTextComponent.text = "Witch, you made fools of those hunters. \n No witch barbeque today!";
        }
        else if (gameStatus.Value == 2)
        {
            print("The hunter has found the witch! Witch loses.");
            textTextComponent.text = "Hunter, the witch has been found \n and burned, as is befitting of heretics. Well done.";
        }
    }
}
