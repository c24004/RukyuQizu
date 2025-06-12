using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OkinawaQuiz
{

    public string question;

    public string okinawaQuiz;

    public string[] answerSelect;

    public string explanationText;
}

[CreateAssetMenu(menuName = "ScriptableObject/Quiz")]

public class ScriptableScript : ScriptableObject
{
    public List<OkinawaQuiz> quizList;

    public string[] tutorialText;
}
