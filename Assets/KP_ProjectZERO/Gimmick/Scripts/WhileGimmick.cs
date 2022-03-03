using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileGimmick : MonoBehaviour
{
    [SerializeField] GameObject hidePanelObj;
    [SerializeField] GameObject closeButtonObj;

    public void WhenGimmickOpen(GameObject gimmickWindowToOpen)
    {
        hidePanelObj.SetActive(true);
        closeButtonObj.SetActive(true);
        gimmickWindowToOpen.SetActive(true);
    }

    public void WhenGimmickClose(GameObject gimmickWindowToClose)
    {
        hidePanelObj.SetActive(false);
        closeButtonObj.SetActive(false);
        gimmickWindowToClose.SetActive(false);
    }
}
