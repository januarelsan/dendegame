using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DiceController : MonoBehaviour
{
    [SerializeField] private Image diceImage;
    [SerializeField] private Sprite[] diceSprites;

    [SerializeField] private Button button;

    void Start(){
        // TossDice();
    }

    public void ActiveButton(bool value){
        button.gameObject.SetActive(value);
        button.interactable = value;
    }
    public void TossDice(){
        diceImage.gameObject.SetActive(true);
        diceImage.transform.DOScale(new Vector3(1.2f,1.2f,0),0.5f).OnComplete(()=>diceImage.transform.DOScale(new Vector3(0.5f,0.5f,0),0.5f).SetSpeedBased());
        

        StartCoroutine(TossDiceIE());
    }

    IEnumerator TossDiceIE(){
        
        int diceNumber = 0; 

        for (int i = 0; i < 10; i++)
        {            
            diceNumber = Random.Range(0,diceSprites.Length);
            diceImage.sprite = diceSprites[diceNumber];
            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(2f); 

        ResetDice();

        DendeGameController.Instance.MoveCharacter(diceNumber + 1);
        
    }

    public void ResetDice(){
        diceImage.gameObject.SetActive(false);
        diceImage.transform.localScale = new Vector3(1,1,1);

    }
}
