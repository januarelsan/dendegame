using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DendeGameController : Singleton<DendeGameController>
{
    [SerializeField] private PowerController powerController;
    [SerializeField] private DirectionController directionController;
    [SerializeField] private BoxController boxController;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private BallController ballController;
    [SerializeField] private DiceController diceController;

    private int currentBoxNumber = 1; // start from 1
    private int ballLandedBoxNumber = 0;
    private int direction = 1;

    public enum GameState
    {
        Throw,
        Toss,
        Jump,
    }

    private GameState gameState = GameState.Throw;



    public void ThrowBall()
    {

        int dirBoxIndex = (int)Math.Round(directionController.GetSliderValue());
        int powerBoxIndex = (int)Math.Round(powerController.GetSliderValue());

        Vector2 moveToValue = new Vector2(boxController.GetDirectionBox(dirBoxIndex).position.x, boxController.GetPowerBox(powerBoxIndex).position.y);
        
        if (boxController.GetBoxWithSamePositionValue(moveToValue) != null)
            ballLandedBoxNumber = boxController.GetBoxWithSamePositionValue(moveToValue).GetNumber();
        else
            ballLandedBoxNumber = -1;

        ballController.MoveToBox(moveToValue);
    }

    public void CheckBallBox()
    {
        if (currentBoxNumber == ballLandedBoxNumber)
        {
            Debug.Log("Correct Box");
            gameState = GameState.Toss;
            powerController.ActivePowerHolder(false);
            directionController.ActiveDirectionHolder(false);
            diceController.ActiveButton(true);
        }
        else
        {
            Debug.Log("Wrong Box");
            powerController.ActivePowerHolder(false);
            directionController.ActiveDirectionHolder(true);
            ballController.ResetPosition();
        }
    }

    public void MoveCharacter(int diceNumber){
        gameState = GameState.Jump;
        StartCoroutine(MoveCharacterIE(diceNumber));
    }

    IEnumerator MoveCharacterIE(int diceNumber){


        bool isEnd = false;        

        int skippedBox = 0;
        for (int i = 0; i < diceNumber; i++)
        {
            int jumpFrom = characterController.GetCurrentBoxNumber();
            Debug.Log("Jump From: " + jumpFrom);
            
            int jumpTo = jumpFrom + direction;            

            if(jumpTo == currentBoxNumber - 1){
                
                Debug.Log("AAA");
                skippedBox = direction;
                jumpTo += skippedBox;
                
                Debug.Log("Jump To: " + jumpTo);
                
                if(!CheckIsEndOfTop(jumpTo)){
                    if(jumpTo >= 0){
                        characterController.MoveToBox(boxController.GetNumberBox(jumpTo).position,jumpTo);
                    } else {
                        characterController.MoveToDefaultPos();
                        ChangeDirection(1);
                        break;
                    }
                    skippedBox = 0;
                } else {
                    characterController.MoveToBox(boxController.GetAllBoxes()[11].position, jumpTo);
                    skippedBox = 0;
                    ChangeDirection(-1);
                    break;
                }

            } else {
                Debug.Log("BBB");
                Debug.Log("To Jump: " + jumpTo);                                
                if(!CheckIsEndOfTop(jumpTo)){
                    
                    if(jumpTo >= 0){
                        characterController.MoveToBox(boxController.GetNumberBox(jumpTo).position,jumpTo);
                    } else {
                        characterController.MoveToDefaultPos();
                        ChangeDirection(1);
                        break;
                    }
                } else {
                    Debug.Log("End");
                    characterController.MoveToBox(boxController.GetAllBoxes()[11].position,jumpTo);
                    ChangeDirection(-1);
                    break;
                }
            }

            yield return new WaitForSeconds(1.5f);
        }

        if (!isEnd)
        {                
            gameState = GameState.Toss;
            diceController.ResetDice();
            diceController.ActiveButton(true);
        }


    }

    bool CheckIsEndOfTop(int jumpTo){
        if(jumpTo >= boxController.GetAllNumberBoxes().Length){
            return true;
        } else {
            return false;
        }
    }

    void ChangeDirection(int direction){
        this.direction = direction;
    }
}
