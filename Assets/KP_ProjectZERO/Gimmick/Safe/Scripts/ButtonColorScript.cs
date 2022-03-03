using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorScript : MonoBehaviour
{
    const int COLOR_RED = 0;
    const int COLOR_GREAN = 1;
    const int COLOR_BLUE = 2;
    const int COLOR_YELLOW = 3;
    const int COLOR_PINK = 4;
    const int COLOR_LIGHTBLUE = 5;
    const int COLOR_WHITE = 6;

    [SerializeField] GameObject[] buttonLamp = new GameObject[3];
    [SerializeField] Color[] buttonColor = new Color[7];

    bool gotBottle = false;
    int[] colorInt = new int[7];

    void Start()
    {
        colorInt[0] = COLOR_RED;
        colorInt[1] = COLOR_GREAN;
        colorInt[2] = COLOR_BLUE;
        colorInt[3] = COLOR_YELLOW;
        colorInt[4] = COLOR_PINK;
        colorInt[5] = COLOR_LIGHTBLUE;
        colorInt[6] = COLOR_WHITE;
    }

    public void PushButtonLamp1()
    {
        ChangeButtonColor (0);
    }

    public void PushButtonLamp2()
    {
        ChangeButtonColor (1);
    }

    public void PushButtonLamp3()
    {
        ChangeButtonColor (2);
    }

     void ChangeButtonColor (int buttonNumber)
    {
        colorInt [buttonNumber]++;
        if (colorInt [buttonNumber] > COLOR_WHITE)//6‚æ‚è‘å‚«‚©‚Á‚½‚ç
        {
            colorInt [buttonNumber] = COLOR_RED;//0‚É–ß‚·
        }
        buttonLamp[buttonNumber].GetComponent<Image>().color =
            buttonColor[colorInt [buttonNumber]];
    }
}
