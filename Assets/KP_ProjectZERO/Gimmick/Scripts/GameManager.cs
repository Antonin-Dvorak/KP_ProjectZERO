using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] GameObject hidePanelObj;
    [SerializeField] GameObject lastPanelObj;

    [Header("Clear��")]
    [SerializeField] GameObject text5;//�悭�ł�����

    [Header("Flags")]
    public bool gotBottle = false;
    public bool gotSyringe = false;
    public bool gotWrist = false;

    [Header("Sounds")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip1;//��b�I���{�^��SE


    void Start()
    {
        roomNumber = ROOM_FRONT;//�J�n���͐^�񒆂̕����������Ă���
    }

    public void PushButtonRight()
    {
        roomNumber++;
        leftButton.SetActive(true);
        if (roomNumber == ROOM_RIGHT)//3
        {
            rightButton.SetActive(false);
        }
        DisplayRoom();

        if ((roomNumber == ROOM_FRONT) & (gotWrist))
        {
            lastPanelObj.SetActive(true);
            Invoke("Clear1", 2);

        }
    }

    public void PushButtonLeft()
    {
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
        hidePanelObj.SetActive(true);
        gimmickWindowToOpen.SetActive(true);
    }

    public void WhenGimmickClose(GameObject gimmickWindowToClose)
    {
        hidePanelObj.SetActive(false);
        gimmickWindowToClose.SetActive(false);
    }

    public void WhenGimmickClear(GameObject gimmickWindowToClear)
    {
        gimmickWindowToClear.GetComponent<Button>().enabled = false;
    }
    
    void Clear1()
    {
        text5.SetActive(true);
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
