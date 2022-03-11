using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject testButton;
    [SerializeField] GameObject bottle2Image;
    [SerializeField] GameObject wristImage;
    [SerializeField] GameObject wristButton;

    void Start()
    {
        
    }

    void AwakeGimmick3()
    {

    }

    public void TouchGimmick3()
    {
        if ((gameManager.gotBottle == true) &&
            (gameManager.gotSyringe == true))
        {
            gameManager.WhenGimmickClear(testButton);
            gameManager.GotAnItem(bottle2Image);
            gameManager.GotAnItem(wristButton);
            gameManager.gotWrist = true;
        }
    }
}
