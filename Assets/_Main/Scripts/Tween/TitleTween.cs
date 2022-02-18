using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleTween : MonoBehaviour
{
    private RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.DOScale(new Vector3(0.95f,0.85f,0.9f), 2).SetLoops(-1, LoopType.Yoyo);
    }
    
    public void Play()
    {
        rectTransform.DOPunchScale(new Vector3(0.1f,0.1f,0.1f), 2, 5, 1);
    }
}
