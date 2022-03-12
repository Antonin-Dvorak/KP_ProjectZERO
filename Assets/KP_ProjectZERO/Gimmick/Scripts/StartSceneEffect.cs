using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartSceneEffect : MonoBehaviour
{
    Image image;
    [SerializeField] GameObject startButton;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.DOFade(1, 0.9f).SetEase(Ease.InCubic);
        image.GetComponent<RectTransform>().DOScale(1, 1f).OnComplete(ButtonOn);
    }

    void ButtonOn()
    {
        startButton.SetActive(true);
    }
}