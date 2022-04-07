using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject spriteRendererObj;
    private Vector3 defaultPosition;
    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToBox(Vector2 value){
        spriteRendererObj.SetActive(true);
        // transform.position = value;
        transform.DOLocalMove(value,2).OnComplete(DendeGameController.Instance.CheckBallBox);
    }

    public void ResetPosition(){
        transform.position = defaultPosition;
    }
}
