using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class TextScript : MonoBehaviour
{
    public PlayerScript playerScript;

    public Text questionText;

    private int answerNum;

    public Image[] choicesImage;

    private float color;

    public Text[] choicesText;

    private readonly string[] defaultText = { null, null, null, null };

    private const int startCount = 0;

    private const int endCount = 10;

    private readonly List<int> questionNum = new();

    private readonly List<int> chanceNum = new();

    private int randomQuestion;

    private readonly string[] talks = { "", "", "", "" };

    public Text startText;

    //public Image questionTextImage;

    //public Sprite[] questionTextSprite;

    //public Text explanationText;

    private int quizCount;

    public Image panelImage;

    //public Image[] iconImage;

    //public Sprite[] iconSprite;

    public Text quizCountText;

    public ScriptableScript scriptable;

    private bool _finishCheck = false;

    private readonly IEnumerator[] enumeQuestion = { null, null };

    public GameObject explanationPanel;

    public Text explanationText;

    private bool _explanationCheck;

    private readonly int quizTimer = 5;

    private string[] randomSelect = { "", "", "", "" };

    private void Start()
    {

        //for(int i = 0; i < 10; i++)
        //{

        //    ResultText.resultQuizText[i] = null;
        //}

        explanationPanel.SetActive(false);

        _explanationCheck = false;

        for (int i = startCount; i < scriptable.quizList.Count; i++)
        {

            questionNum.Add(i);

            chanceNum.Add(i);
        }

        quizCountText.text = quizCount + "/" + endCount;

        color = 1;

        panelImage.color = new Color(color, color, color, color);

        InvokeRepeating(nameof(PanelImage), 0.01f, 0.01f);

        for(int i = 0; i <= 3; i++)
        {

            defaultText[i] = choicesText[i].text;
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {

            if (!_explanationCheck) return;

            explanationPanel.SetActive(false);

            _explanationCheck = false;

            Quiz();
        }
    }

    void PanelImage()
    {

        if (color >= 0)
        {

            color -= Time.deltaTime;

            panelImage.color = new Color(color, color, color, color);
        }
        else
        {

            color = 0;

            panelImage.color = new Color(color, color, color, color);

            StartCoroutine(StratQuiz());

            CancelInvoke(nameof(PanelImage));
        }
    }

    IEnumerator StratQuiz()
    {
        startText.text = "3";
        yield return new WaitForSeconds(1);
        startText.text = "2";
        yield return new WaitForSeconds(1);
        startText.text = "1";
        yield return new WaitForSeconds(1);
        startText.text = "GO";
        yield return new WaitForSeconds(1);
        startText.text = "";
        Quiz();
        yield break;
    }

    void Quiz()
    {

        if (quizCount < endCount)
        {

            quizCount += 1;
        }
        else
        {

            _finishCheck = true;
        }

        quizCountText.text = quizCount + "/" + endCount;

        color = 1;

        for (int i = 0; i < 4; i++)
        {

            choicesImage[i].color = new Color(color, color, color, color);

            choicesText[i].color = new Color(0, 0, 0, color);
        }

        //questionTextImage.sprite = questionTextSprite[0];

        //explanationText.text = "";

        for (int i = 0; i < 4; i++)
        {

            choicesText[i].text = defaultText[i];
        }

        playerScript.SelectReset();

        if (_finishCheck == false)
        {

            StartCoroutine(Dialogue());

            ResultText.resultQuizText[quizCount - 1] = scriptable.quizList[randomQuestion].question;

            ResultText.resultAnswerText[quizCount - 1] = scriptable.quizList[randomQuestion].answerSelect[0];
        }
        else
        {

            color = 0;

            questionText.text = "";

            playerScript.FinishPoint();

            InvokeRepeating(nameof(SceneFinish), 0.01f, 0.01f);
        }
    }

    public void FinishQuestion()
    {

        StopCoroutine(enumeQuestion[0]);

        StopCoroutine(enumeQuestion[1]);

        enumeQuestion[0] = null;

        enumeQuestion[1] = null;

        //playerScript.AnswerPoint(answerNum);

        playerScript.PlayerAnswer(answerNum);

        //questionTextImage.sprite = questionTextSprite[1];

        ButtonFalse();

        Answer();

        //iconImage[0].sprite = iconSprite[TutorialChara.chara[0]];

        //iconImage[1].sprite = iconSprite[TutorialChara.chara[1]];

        StartCoroutine(ExplanationText());

        AnswerCheck._answer = false;
    }

    IEnumerator ExplanationText()
    {

        startText.text = "";
        yield return new WaitForSeconds(1);
        startText.text = "3";
        yield return new WaitForSeconds(1);
        startText.text = "2";
        yield return new WaitForSeconds(1);
        startText.text = "1";
        yield return new WaitForSeconds(1);
        startText.text = "";
        _explanationCheck = true;
        explanationPanel.SetActive(true);
        explanationText.text = scriptable.quizList[randomQuestion].explanationText;
        yield break;
    }

    IEnumerator Dialogue()
    {

        RondomQuestion();

        questionText.text = "問題" + "\n";

        foreach (char word in talks[0])
        {
            questionText.text += word;
            yield return new WaitForSeconds(0.1f);
        }

        playerScript.StartTimer();

        RandomAnswer();

        enumeQuestion[0] = OkinawaQuestion();

        enumeQuestion[1] = QuestionDelete();

        StartCoroutine(enumeQuestion[0]);

        StartCoroutine(enumeQuestion[1]);

        AnswerCheck._answer = true;

        yield break;
    }

    void RondomQuestion()
    {

        int index = Random.Range(0, questionNum.Count);

        randomQuestion = questionNum[index];

        questionNum.RemoveAt(index);

        talks[0] = scriptable.quizList[randomQuestion].okinawaQuiz;

        talks[1] = scriptable.quizList[randomQuestion].question;

        //talks[2] = "解説　：　";
    }

    void RandomAnswer()
    {

        List<int> allAnswer = new();
        List<int> allQuiz = new();
        for (int i = 0; i <= 3; i++) allAnswer.Add(i);
        for (int i = 0; i <= 3; i++) allQuiz.Add(i);

        while (allAnswer.Count > 0)
        {

            int randomAnswer = Random.Range(0, allAnswer.Count);
            int randomQuiz = Random.Range(0, allQuiz.Count);

            int answerCount = allAnswer[randomAnswer];
            int quizNum = allQuiz[randomQuiz];

            randomSelect[quizNum] = scriptable.quizList[randomQuestion].answerSelect[answerCount];

            choicesText[quizNum].text = randomSelect[quizNum];

            //Debug.Log(randomSelect[count] + " " + count);

            if (answerCount == 0)
            {
                this.answerNum = quizNum;
            }

            allQuiz.RemoveAt(randomQuiz);
            allAnswer.RemoveAt(randomAnswer);
        }

    }

    public void Answer()
    {

        playerScript.OkImageFalse();

        //explanationText.text = talks[2];
        questionText.text = "正解は 「" + scriptable.quizList[randomQuestion].answerSelect[0] + "」でした";

        ResultText.answerTextP1[quizCount - 1] = randomSelect[ResultText.answerP1];

        ResultText.answerTextP2[quizCount - 1] = randomSelect[ResultText.answerP2];

        //if (answerNum == 0)
        //{
        //    questionText.text = "正解は　「赤色」　でした";
        //}

        //else if (answerNum == 1)
        //{
        //    questionText.text = "正解は　「青色」　でした";
        //}

        //else if (answerNum == 2)
        //{
        //    questionText.text = "正解は　「橙色」　でした";

        //}

        //else if (answerNum == 3)
        //{
        //    questionText.text = "正解は　「黄色」　でした";

        //}
    }

    public void ButtonFalse()
    {

        if (answerNum == 0)
        {
            InvokeRepeating(nameof(ImageButton0), 0.01f, 0.01f);
        }
        else if (answerNum == 1)
        {
            InvokeRepeating(nameof(ImageButton1), 0.01f, 0.01f);
        }
        else if (answerNum == 2)
        {
            InvokeRepeating(nameof(ImageButton2), 0.01f, 0.01f);
        }
        else if (answerNum == 3)
        {
            InvokeRepeating(nameof(ImageButton3), 0.01f, 0.01f);
        }
    }

    void ImageButton0()
    {
        if (color >= 0)
        {

            color -= Time.deltaTime;
        }
        else
        {
            color = 0;
        }

        choicesImage[1].color = new Color(color, color, color, color);
        choicesText[1].color = new Color(0, 0, 0, color);

        choicesImage[2].color = new Color(color, color, color, color);
        choicesText[2].color = new Color(0, 0, 0, color);

        choicesImage[3].color = new Color(color, color, color, color);
        choicesText[3].color = new Color(0, 0, 0, color);

        if (color == 0) CancelInvoke(nameof(ImageButton0));
    }

    void ImageButton1()
    {

        if (color >= 0)
        {

            color -= Time.deltaTime;
        }
        else
        {

            color = 0;
        }

        choicesImage[0].color = new Color(color, color, color, color);
        choicesText[0].color = new Color(0, 0, 0, color);

        choicesImage[2].color = new Color(color, color, color, color);
        choicesText[2].color = new Color(0, 0, 0, color);

        choicesImage[3].color = new Color(color, color, color, color);
        choicesText[3].color = new Color(0, 0, 0, color);

        if (color == 0) CancelInvoke(nameof(ImageButton1));
    }

    void ImageButton2()
    {

        if (color >= 0)
        {
            color -= Time.deltaTime;
        }
        else
        {
            color = 0;
        }

        choicesImage[0].color = new Color(color, color, color, color);
        choicesText[0].color = new Color(0, 0, 0, color);

        choicesImage[1].color = new Color(color, color, color, color);
        choicesText[1].color = new Color(0, 0, 0, color);

        choicesImage[3].color = new Color(color, color, color, color);
        choicesText[3].color = new Color(0, 0, 0, color);

        if (color == 0) CancelInvoke(nameof(ImageButton2));
    }

    void ImageButton3()
    {

        if (color >= 0)
        {
            color -= Time.deltaTime;
        }
        else
        {
            color = 0;
        }
        choicesImage[0].color = new Color(color, color, color, color);
        choicesText[0].color = new Color(0, 0, 0, color);

        choicesImage[1].color = new Color(color, color, color, color);
        choicesText[1].color = new Color(0, 0, 0, color);

        choicesImage[2].color = new Color(color, color, color, color);
        choicesText[2].color = new Color(0, 0, 0, color);

        if (color == 0) CancelInvoke(nameof(ImageButton3));
    }

    public void SceneFinish()
    {

        if (color <= 1)
        {

            color += Time.deltaTime;

            panelImage.color = new Color(color, color, color, color);
        }
        else
        {

            color = 1;

            panelImage.color = new Color(color, color, color, color);

            SceneManager.LoadScene("ResultScene");
        }
    }

    IEnumerator OkinawaQuestion()
    {

        yield return new WaitForSeconds(quizTimer);

        talks[3] = "";

        foreach (char word in talks[1])
        {

            talks[3] += word;

            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator QuestionDelete()
    {

        yield return new WaitForSeconds(quizTimer);

        string deleteQuiz = talks[0];

        while (questionText.text != "問題" + "\n" + talks[1])
        {

            deleteQuiz = deleteQuiz[1..];

            questionText.text = "問題" + "\n" + talks[3] + deleteQuiz;

            if (talks[1] == talks[3])
            {
                questionText.text = "問題" + "\n" + talks[1];
            }

            yield return new WaitForSeconds(0.1f);
        }

        yield break;
    }

    //IEnumerator ExplanationText()
    //{

    //    yield return new WaitForSeconds(3);

        
    //}
}
