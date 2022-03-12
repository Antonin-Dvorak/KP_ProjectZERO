using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextButton : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [Header("Sounds")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip_kati;



    void Awake()
    {
        GetComponent<RectTransform>().DOLocalMove(new Vector3(339f, -110f, 0f), 0.5f).SetEase(Ease.InQuad).SetLoops(-1, LoopType.Yoyo);
    }

    public void ClickToSound()
    {
        gameManager.SoundSE(clip_kati);
    }
}
