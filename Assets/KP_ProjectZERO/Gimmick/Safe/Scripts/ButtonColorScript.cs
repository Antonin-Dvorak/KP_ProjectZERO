using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorScript : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject window_Safe;//他のギミックでは不要な変数
    [SerializeField] GameObject clearSafeImage;//他のギミックでは不要な変数
    [SerializeField] GameObject safeButton;
    [SerializeField] GameObject bottleButton;

    const int COLOR_RED = 0;
    const int COLOR_GREAN = 1;
    const int COLOR_BLUE = 2;
    const int COLOR_YELLOW = 3;
    const int COLOR_PINK = 4;
    const int COLOR_LIGHTBLUE = 5;
    const int COLOR_GRAY = 6;

    [SerializeField] GameObject[] buttonLamp = new GameObject[3];
    [SerializeField] GameObject closeButton;
[SerializeField] Color[] buttonColor = new Color[7];
    int[] colorInt = new int[7];

    [Header("Sounds")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip_kati;
    [SerializeField] AudioClip clip_open;

    void Start()
    {
        colorInt[0] = COLOR_RED;
        colorInt[1] = COLOR_GREAN;
        colorInt[2] = COLOR_BLUE;
        colorInt[3] = COLOR_YELLOW;
        colorInt[4] = COLOR_PINK;
        colorInt[5] = COLOR_LIGHTBLUE;
        colorInt[6] = COLOR_GRAY;
    }

    public void PushButtonLamp1()
    {
        ChangeButtonColor(0);
    }

    public void PushButtonLamp2()
    {
        ChangeButtonColor(1);
    }

    public void PushButtonLamp3()
    {
        ChangeButtonColor(2);
    }

    void ChangeButtonColor(int buttonNumber)
    {
        colorInt[buttonNumber]++;
        if (colorInt[buttonNumber] > COLOR_GRAY)//6より大きかったら
        {
            colorInt[buttonNumber] = COLOR_RED;//0に戻す
        }
        buttonLamp[buttonNumber].GetComponent<Image>().color =
            buttonColor[colorInt[buttonNumber]];

        if ((colorInt[0] == COLOR_GRAY) &&
            (colorInt[1] == COLOR_PINK) &&
            (colorInt[2] == COLOR_LIGHTBLUE))
        {
            Debug.Log("True");
            for (int i = 0; i < 3; ++i)
            {
                buttonLamp[i].GetComponent<Button>().enabled = false;
            }
            closeButton.GetComponent<Button>().enabled = false;
            audioSource.PlayOneShot(clip_open);
            Invoke("FinishSafeGimmik", 1);
        }
        audioSource.PlayOneShot(clip_kati);
    }

    void FinishSafeGimmik()
    {
        clearSafeImage.SetActive(true);
        gameManager.gotBottle = true;
        gameManager.WhenGimmickClear(safeButton);
        gameManager.GotAnItem(bottleButton);
        Destroy(window_Safe.gameObject);
    }
}
