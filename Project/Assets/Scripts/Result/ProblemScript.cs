using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public static class ResultText
{

    public static string[] resultQuizText = { "", "", "", "", "", "", "", "", "", "" };

    public static string[] resultAnswerText = { "", "", "", "", "", "", "", "", "", "" };

    public static int answerP1;

    public static string[] answerTextP1 = { "", "", "", "", "", "", "", "", "", "" };

    public static int answerP2;

    public static string[] answerTextP2 = { "", "", "", "", "", "", "", "", "", "" };
}

public class ProblemScript : MonoBehaviour
{

    private bool isPanel = false;

    public GameObject panelObj;

    public Text quizText;

    private int textCount = 0;

    public Text pageCountText;

    public Text answerText;

    public Text[] selectText;

    public Image[] charaImage;

    public Sprite[] charaP1Spreite;

    public Sprite[] charaP2Spreite;

    private void Start()
    {

        panelObj.SetActive(false);

        quizText.text = ResultText.resultQuizText[textCount];

        answerText.text = ResultText.resultAnswerText[textCount];

        selectText[0].text = ResultText.answerTextP1[textCount];

        selectText[1].text = ResultText.answerTextP2[textCount];

        charaImage[0].sprite = charaP1Spreite[TutorialChara.chara[0]];

        charaImage[1].sprite = charaP2Spreite[TutorialChara.chara[1]];
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isPanel)
            {

                panelObj.SetActive(false);

                isPanel = false;
            }
            else
            {

                panelObj.SetActive(true);

                isPanel = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (!isPanel) return;

            if(textCount == 9)
            {
                return;
            }
            else
            {
                textCount += 1;
            }

            quizText.text = ResultText.resultQuizText[textCount];

            answerText.text = ResultText.resultAnswerText[textCount];

            selectText[0].text = ResultText.answerTextP1[textCount];

            selectText[1].text = ResultText.answerTextP2[textCount];

            pageCountText.text = textCount + 1 + "/" + 10;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (!isPanel) return;

            if (textCount == 0)
            {
                return;
            }
            else
            {
                textCount -= 1;
            }

            quizText.text = ResultText.resultQuizText[textCount];

            answerText.text = ResultText.resultAnswerText[textCount];

            selectText[0].text = ResultText.answerTextP1[textCount];

            selectText[1].text = ResultText.answerTextP2[textCount];

            pageCountText.text = textCount + 1 + "/" + 10;
        }
    }
}
