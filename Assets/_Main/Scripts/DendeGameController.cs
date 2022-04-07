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

    public enum GameState
    {
        Throw,
        Toss,
        Jump,
    }

    private GameState gameState = GameState.Throw;



    public void ThrowBall()
    {
        // Debug.Log(directionController.GetSliderValue());
        // Debug.Log(powerController.GetSliderValue());

        int dirBoxIndex = (int)Math.Round(directionController.GetSliderValue());
        int powerBoxIndex = (int)Math.Round(powerController.GetSliderValue());

        // Debug.Log(dirBoxIndex);
        // Debug.Log(powerBoxIndex);

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

        Debug.Log("Dice Number: " + diceNumber);

        bool isEnd = false;

        int skippedBox = 0;
        for (int i = 0; i < diceNumber; i++)
        {
            int jumpFrom = characterController.GetCurrentBoxNumber();
            int jumpTo = jumpFrom;
            Debug.Log("To Jump: " + jumpTo);
            if(jumpTo + 1 == currentBoxNumber){
                // Debug.Log("Skip : " + boxController.GetNumberBox(i).GetComponent<Box>().GetNumber());
                skippedBox++;
                jumpTo += skippedBox;

                // Debug.Log("Jump After Skip : " + boxController.GetNumberBox(toJump).GetComponent<Box>().GetNumber());
                if(!CheckIsEndOfTop(jumpTo)){
                    characterController.MoveToBox(boxController.GetNumberBox(jumpTo).position,1);
                    skippedBox--;
                } else {
                    characterController.MoveToBox(boxController.GetAllBoxes()[11].position);
                    isEnd = true;
                }

            } else {
                jumpTo += skippedBox;

                if(!CheckIsEndOfTop(jumpTo)){
                    // Debug.Log("Jump : " + boxController.GetNumberBox(toJump).GetComponent<Box>().GetNumber());
                    characterController.MoveToBox(boxController.GetNumberBox(jumpTo).position);
                } else {
                    characterController.MoveToBox(boxController.GetAllBoxes()[11].position);
                    isEnd = true;
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
}
