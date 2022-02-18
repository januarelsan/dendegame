using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayButtonTween : MonoBehaviour
{
    private RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.DOPunchScale(new Vector3(0.1f,0.1f,0.1f), 2, 2, 1).SetDelay(5).SetLoops(-1,LoopType.Restart);
    }
    
    public void Play()
    {
        
    }
}
