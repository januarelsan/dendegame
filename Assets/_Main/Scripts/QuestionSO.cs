using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "ScriptableObjects/Question", order = 1)]
public class QuestionSO : ScriptableObject
{
    public string question;
    public string[] options;
    public int correctOptionIndex;
}