using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PIN : MonoBehaviour {
    public Sprite[] numbers;
    public Image[] images;
    private int[] nows = {0, 0, 0, 0};

    [Header("Reference")]
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject pinButton;
    [SerializeField] GameObject syringeButton;

    public void CangeNumber(int n) 
    {
        nows[n] += 1;
        if(nows[n] >= numbers.Length) 
        {
           nows[n] = 0;
        }
        images[n].sprite = numbers[nows[n]];
    }

    public void PushOKButton()
    {
        if ((nows[0] == 2) &&
            (nows[1] == 0) &&
            (nows[2] == 4) &&
            (nows[3] == 6))
        {
            gameManager.gotSyringe = true;
            gameManager.WhenGimmickClear(pinButton);
            gameManager.GotAnItem(syringeButton);
            Destroy(this.gameObject);
        }
    }
}