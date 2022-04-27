using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : Singleton<QuestionController>
{
    [SerializeField] private GameObject questionPanel;
    [SerializeField] private Text questionText;
    [SerializeField] private Text[] optionTextArray;
    [SerializeField] private QuestionSO[] questionSOs;
    List<int>  questionIndex = new List<int>();

    private int currentQuestionIndex = 0;

    private QuestionSO currentSO;

    private Color defaultOptionButtonColor;

    void Awake(){
        defaultOptionButtonColor = optionTextArray[0].transform.parent.GetComponent<Image>().color;
        SetupQuestions();
    }

    void SetupQuestions(){
        for (int i = 0; i < questionSOs.Length; i++)
        {
            questionIndex.Add(i);
        }

        for (int i = 0; i < 25; i++)
        {
            int x = Random.Range(0,questionIndex.Count);
            int y = Random.Range(0,questionIndex.Count);

            int tempValue = questionIndex[x];
            questionIndex[x] = questionIndex[y];
            questionIndex[y] = tempValue;
        }
    }

    public void ActivePanel(){
        questionPanel.SetActive(true);
        currentSO = questionSOs[questionIndex[currentQuestionIndex]];

        questionText.text = currentSO.question;

        for (int i = 0; i < optionTextArray.Length; i++)
        {
            //reset color
            optionTextArray[i].transform.parent.GetComponent<Image>().color = defaultOptionButtonColor;

            if(i < currentSO.options.Length){
                optionTextArray[i].transform.parent.gameObject.SetActive(true);
                optionTextArray[i].text = currentSO.options[i];
            } else
            {
                optionTextArray[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }

    public void Answer(int optionIndex){
        if(optionIndex == currentSO.correctOptionIndex){
            optionTextArray[optionIndex].transform.parent.GetComponent<Image>().color = Color.green;
            questionPanel.SetActive(false);

            currentQuestionIndex++;

            Debug.Log(currentQuestionIndex);
            if(currentQuestionIndex >= questionIndex.Count){
                currentQuestionIndex = 0;
            }

        } else {
            optionTextArray[optionIndex].transform.parent.GetComponent<Image>().color = Color.red;
            
        }
    }
}
