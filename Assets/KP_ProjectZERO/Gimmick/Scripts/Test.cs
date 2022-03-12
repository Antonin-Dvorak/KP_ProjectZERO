using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Test : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject testButton;
    [SerializeField] GameObject bottle2Image;
    [SerializeField] GameObject wristImage;
    [SerializeField] GameObject wristButton;
    [SerializeField] GameObject text;

    [Header("Sounds")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip_wrist_cut;

    Image image;
    void Start()
    {
        image = gameManager.hidePanelObj.GetComponent<Image>();
    }

    void AwakeGimmick3()
    {

    }

    public void TouchGimmick3()
    {
        if ((gameManager.gotBottle == true) &&
            (gameManager.gotSyringe == true))
        {
            image.color = new Color(0f, 0f, 0f, 0f);
            gameManager.hidePanelObj.SetActive(true);
            image.DOFade(0.25f, 1f).SetEase(Ease.Linear).OnComplete(TouchGimmick3_0);
        }
    }

    void TouchGimmick3_0()
    {
        text.SetActive(true);
    }

    public void TouchGimmick3_1()
    {
        image.DOFade(1f, 2.5f).OnComplete(TouchGimmick3_2);
        audioSource.PlayOneShot(clip_wrist_cut);
    }

    void TouchGimmick3_2()
    {
        image.color = new Color(1f, 0f, 0f, 1f);//ê‘
        Invoke("TouchGimmick3_3", 0.2f);
    }

    void TouchGimmick3_3()
    {
        image.color = new Color(0f, 0f, 0f, 1f);
        image.DOFade(0.4f, 2f).OnComplete(TouchGimmick3_4);
    }

    void TouchGimmick3_4()
    {
        gameManager.WhenGimmickClear(testButton);
        gameManager.GotAnItem(bottle2Image);
        gameManager.GotAnItem(wristButton);
        gameManager.gotWrist = true;
    }
}
