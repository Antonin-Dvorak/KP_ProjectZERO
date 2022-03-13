using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    const int ROOM_LEFT = 1;
    const int ROOM_FRONT = 2;
    const int ROOM_RIGHT = 3;
    int roomNumber;

    [Header("UI")]
    [SerializeField] GameObject panelRooms;
    [SerializeField] GameObject rightButton;
    [SerializeField] GameObject leftButton;
    [SerializeField] public GameObject hidePanelObj;
    [SerializeField] GameObject lastPanelObj;

    [Header("Clear後")]
    [SerializeField] GameObject clearBackImage;
    [SerializeField] GameObject clearBackImage2;
    [SerializeField] GameObject text5;//よくできたね
    [SerializeField] GameObject sister1;
    [SerializeField] GameObject sister2;
    [SerializeField] GameObject clearLogo;
    [SerializeField] GameObject credits;

    [Header("Flags")]
    public bool gotBottle = false;
    public bool gotSyringe = false;
    public bool gotWrist = false;
    bool finish = false;
    bool startGr = false;

    [Header("Sounds")]
    [SerializeField] PostProcessVolume ppVolume;
    Grain gr;
    LensDistortion ld;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip_kati;//移動ボタン
    [SerializeField] AudioClip clip_tap;//ギミックウィンドウオープン
    [SerializeField] AudioClip clip_cancel;//ギミックウィンドウクローズ
    [SerializeField] AudioClip clip_get_item;//移動ボタン
    [SerializeField] AudioClip clip_appear;

    void Start()
    {
        gr = ppVolume.profile.GetSetting<Grain>();
        ld = ppVolume.profile.GetSetting<LensDistortion>();
        roomNumber = ROOM_FRONT;//開始時は真ん中の部屋を向いている
    }

    public void PushButtonRight()
    {
        SoundSE(clip_kati);
        roomNumber++;
        leftButton.SetActive(true);
        if (roomNumber == ROOM_RIGHT)//3
        {
            rightButton.SetActive(false);
        }
        DisplayRoom();

        if ((roomNumber == ROOM_FRONT) & (gotWrist))
        {
            audioSource.Stop();
            SoundSE(clip_appear);
            clearBackImage.SetActive(true);//手がでる
            Invoke("Clear1", 3f);
        }
    }

    void Clear1()//フェード
    {
        lastPanelObj.SetActive(true);
        lastPanelObj.GetComponent<Image>().DOFade(1f, 0.5f).SetEase(Ease.InQuad).SetLoops(2, LoopType.Yoyo);
        Invoke("Clear2", 0.5f);
    }

    void Clear2()//妹登場、テキスト
    {
        clearBackImage2.SetActive(true);
        sister1.SetActive(true);
        text5.SetActive(true);
        Invoke("Clear3", 3f);
    }

    void Clear3()//フェード
    {
        lastPanelObj.SetActive(true);
        lastPanelObj.GetComponent<Image>().DOFade(1f, 0.5f).SetEase(Ease.InQuad).SetLoops(2, LoopType.Yoyo);
        Invoke("Clear4", 0.5f);
    }

    void Clear4()//妹2
    {
        sister1.SetActive(true);
        sister2.SetActive(true);
        Invoke("Clear5", 2f);

    }

    void Update()
    {

        if (startGr)
        {
                gr.intensity.value += 0.001f;
                ld.intensity.value -= 0.03f;
        }
    }
    void Clear5()//だんだん暗くなる＋ポスプロ
    {

        startGr = true;
        hidePanelObj.SetActive(true);
        hidePanelObj.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.0f);
        hidePanelObj.GetComponent<Image>().DOFade(1f, 4f).SetEase(Ease.Linear).OnComplete(Clear6);
        Invoke("Clear6", 7f);

    }

    void Clear6()//フェード
    {
        startGr = false;
        text5.SetActive(false);
        lastPanelObj.SetActive(true);
        lastPanelObj.GetComponent<Image>().DOFade(1f, 2f).OnComplete(Clear7);
    }

    void Clear7()//クリアの文字
    {
        gr.intensity.value = 0f;
        ld.intensity.value = 0f;

        sister2.SetActive(false);
        clearLogo.SetActive(true);
        Invoke("Clear8", 1.5f);
    }

    void Clear8()//クレジットと制作
    {
        credits.SetActive(true);
        Invoke("GoStart", 10f);
    }

    void GoStart()//スタートへ
    {
        SceneManager.LoadScene("Start");
    }




    public void PushButtonLeft()
    {
        SoundSE(clip_kati);
        roomNumber--;
        rightButton.SetActive(true);
        if (roomNumber == ROOM_LEFT)//1
        {
            leftButton.SetActive(false);
        }
        DisplayRoom();
    }

    void DisplayRoom()
    {
        switch (roomNumber)
        {
            case ROOM_LEFT:
                panelRooms.transform.localPosition = new Vector3(1000f, 0f, 0f);
                break;
            case ROOM_FRONT:
                panelRooms.transform.localPosition = new Vector3(0f, 0f, 0f);
                break;
            case ROOM_RIGHT:
                panelRooms.transform.localPosition = new Vector3(-1000f, 0f, 0f);
                break;
        }
    }


    public void WhenGimmickOpen(GameObject gimmickWindowToOpen)
    {
        SoundSE(clip_tap);
        hidePanelObj.SetActive(true);
        gimmickWindowToOpen.SetActive(true);
    }

    public void WhenGimmickClose(GameObject gimmickWindowToClose)
    {
        SoundSE(clip_cancel);
        hidePanelObj.SetActive(false);
        gimmickWindowToClose.SetActive(false);
    }

    public void WhenGimmickClear(GameObject gimmickWindowToClear)
    {
        SoundSE(clip_get_item);
        gimmickWindowToClear.GetComponent<Button>().enabled = false;
    }




    public void GotAnItem(GameObject item)
    {
        item.SetActive(true);
    }

    public void ShowMessage(GameObject textObj)
    {
        textObj.SetActive(true);
    }


    public void ButtonFalse(GameObject buttonObj)
    {
        buttonObj.SetActive(false);
    }

    public void ButtonFalse2(GameObject getItemObj)
    {
        getItemObj.SetActive(true);
    }

    public void ButtonFalse3(GameObject usedItemObj)
    {
        usedItemObj.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
    }

    public void SoundSE(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
