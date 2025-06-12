using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class AnswerCheck
{

    public static bool _answer = false;
}

public class PlayerScript : MonoBehaviour
{
    public TextScript textScript;

    //public Text[] selectText;

    private readonly int[] selectNum = { 0, 0 };

    private readonly float[] answerSpeed = { 0, 0 };

    //private readonly string[] answerSelect = { "", "" };

    public GameObject[] okImageObj;

    //private bool _answer = false;

    public GameObject[] timerObjP1;

    public GameObject[] timerObjP2;

    readonly private IEnumerator[] tankEnume = { null, null };

    //readonly private int[] answerCount = { 0, 0 };

    private IEnumerator finishEnume;

    public Text timerText;

    public int timeSpeed;

    private readonly int[] timerCount = { 5, 5 };

    private bool _finishChack = false;

    private float color;

    public Image panelImage;

    private  float timeSecond;

    private readonly int[] point = { 0, 0 };

    public Image[] charaImage;

    public Sprite[] normalSprite1P;

    public Sprite[] normalSprite2P;

    public Sprite[] happySprite1P;

    public Sprite[] happySprite2P;

    public Sprite[] sadSprite1P;

    public Sprite[] sadSprite2P;

    public AudioClip sound1;

    AudioSource audioSource;

    private void Start()
    {

        tankEnume[0] = TankTimer1();

        tankEnume[1] = TankTimer2();

        finishEnume = FinishAnswer();

        timerText.text = "";

        okImageObj[0].SetActive(false);

        okImageObj[1].SetActive(false);

        charaImage[0].sprite = normalSprite1P[TutorialChara.chara[0]];

        charaImage[1].sprite = normalSprite2P[TutorialChara.chara[1]];

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (AnswerCheck._answer)
        {

            timeSecond -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.W))
            {

                if (selectNum[0] != 4) return; //&& answerCount[0] > 2) return;

                selectNum[0] = 0;

                //answerSelect[0] = "A";

                ResultText.answerP1 = 0;

                answerSpeed[0] = timeSecond;

                StopCoroutine(tankEnume[0]);

                audioSource.PlayOneShot(sound1);

                if (selectNum[0] != 4 && selectNum[1] != 4)
                {

                    //answerCount[0] += 1;

                    StopCoroutine(finishEnume);

                    finishEnume = null;

                    finishEnume = FinishAnswer();

                    StartCoroutine(finishEnume);
                }

                okImageObj[0].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {

                if (selectNum[0] != 4) return;// && answerCount[0] > 2) return;

                selectNum[0] = 1;

                //answerSelect[0] = "B";

                ResultText.answerP1 = 1;

                answerSpeed[0] = timeSecond;

                StopCoroutine(tankEnume[0]);

                audioSource.PlayOneShot(sound1);

                if (selectNum[0] != 4 && selectNum[1] != 4)
                {

                    //answerCount[0] += 1;

                    StopCoroutine(finishEnume);

                    finishEnume = null;

                    finishEnume = FinishAnswer();

                    StartCoroutine(finishEnume);
                }

                okImageObj[0].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {

                if (selectNum[0] != 4) return;// && answerCount[0] > 2) return;

                selectNum[0] = 2;

                //answerSelect[0] = "C";

                ResultText.answerP1 = 2;

                answerSpeed[0] = timeSecond;

                StopCoroutine(tankEnume[0]);

                audioSource.PlayOneShot(sound1);

                if (selectNum[0] != 4 && selectNum[1] != 4)
                {

                    //answerCount[0] += 1;

                    StopCoroutine(finishEnume);

                    finishEnume = null;

                    finishEnume = FinishAnswer();

                    StartCoroutine(finishEnume);
                }

                okImageObj[0].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {

                if (selectNum[0] != 4) return;// && answerCount[0] > 2) return;

                selectNum[0] = 3;

                //answerSelect[0] = "D";

                ResultText.answerP1 = 3;

                answerSpeed[0] = timeSecond;

                StopCoroutine(tankEnume[0]);

                audioSource.PlayOneShot(sound1);

                if (selectNum[0] != 4 && selectNum[1] != 4)
                {

                    //answerCount[0] += 1;

                    StopCoroutine(finishEnume);

                    finishEnume = null;

                    finishEnume = FinishAnswer();

                    StartCoroutine(finishEnume);
                }

                okImageObj[0].SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                if (selectNum[1] != 4) return;// && answerCount[1] > 2) return;

                selectNum[1] = 0;

                //answerSelect[1] = "A";

                ResultText.answerP2 = 0;

                answerSpeed[1] = timeSecond;

                StopCoroutine(tankEnume[1]);

                audioSource.PlayOneShot(sound1);

                if (selectNum[0] != 4 && selectNum[1] != 4)
                {

                    //answerCount[1] += 1;

                    StopCoroutine(finishEnume);

                    finishEnume = null;

                    finishEnume = FinishAnswer();

                    StartCoroutine(finishEnume);
                }

                okImageObj[1].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                if (selectNum[1] != 4) return;// && answerCount[1] > 2) return;

                selectNum[1] = 1;

                //answerSelect[1] = "B";

                ResultText.answerP2 = 1;

                answerSpeed[1] = timeSecond;

                StopCoroutine(tankEnume[1]);

                audioSource.PlayOneShot(sound1);

                if (selectNum[0] != 4 && selectNum[1] != 4)
                {

                    //answerCount[1] += 1;

                    StopCoroutine(finishEnume);

                    finishEnume = null;

                    finishEnume = FinishAnswer();

                    StartCoroutine(finishEnume);
                }

                okImageObj[1].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                if (selectNum[1] != 4) return;// && answerCount[1] > 2) return;

                selectNum[1] = 2;

                //answerSelect[1] = "C";

                ResultText.answerP2 = 2;

                answerSpeed[1] = timeSecond;

                StopCoroutine(tankEnume[1]);

                audioSource.PlayOneShot(sound1);

                if (selectNum[0] != 4 && selectNum[1] != 4)
                {

                    //answerCount[1] += 1;

                    StopCoroutine(finishEnume);

                    finishEnume = null;

                    finishEnume = FinishAnswer();

                    StartCoroutine(finishEnume);
                }

                okImageObj[1].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                if (selectNum[1] != 4) return;// && answerCount[1] > 2) return;

                selectNum[1] = 3;

                //answerSelect[1] = "D";

                ResultText.answerP2 = 3;

                answerSpeed[1] = timeSecond;

                StopCoroutine(tankEnume[1]);

                audioSource.PlayOneShot(sound1);

                if (selectNum[0] != 4 && selectNum[1] != 4)
                {

                    //answerCount[1] += 1;

                    StopCoroutine(finishEnume);

                    finishEnume = null;

                    finishEnume = FinishAnswer();

                    StartCoroutine(finishEnume);
                }

                okImageObj[1].SetActive(true);
            }
        }

        if (Input.GetMouseButtonDown(2))
        {

            Debug.Log(color);
        }
    }

    public void SelectReset()
    {

        selectNum[0] = 4;
        selectNum[1] = 4;

        //selectText[0].text = "";
        //selectText[1].text = "";

        //answerSelect[0] = "";
        //answerSelect[1] = "";

        answerSpeed[0] = 0;
        answerSpeed[1] = 0;

        charaImage[0].sprite = normalSprite1P[TutorialChara.chara[0]];
        charaImage[1].sprite = normalSprite2P[TutorialChara.chara[1]];

        //answerCount[0] = 0;
        //answerCount[1] = 0;
    }

    public void OkImageFalse()
    {

        okImageObj[0].SetActive(false);
        okImageObj[1].SetActive(false);
    }

    //void AnswerPoint(int answer)
    //{

    //    //selectText[0].text = answerSelect[0];

        
    //}

    public void PlayerAnswer(int answer)
    {

        if (selectNum[0] == selectNum[1] && selectNum[0] == answer)
        {

            charaImage[0].sprite = happySprite1P[TutorialChara.chara[0]];

            charaImage[1].sprite = happySprite2P[TutorialChara.chara[1]];

            if (answerSpeed[0] > answerSpeed[1])
            {

                point[0] += 1;
            }
            else
            {

                point[1] += 1;
            }
        }
        else
        {

            if (selectNum[0] == answer)
            {

                point[0] += 1;

                charaImage[0].sprite = happySprite1P[TutorialChara.chara[0]];
            }
            else
            {

                charaImage[0].sprite = sadSprite1P[TutorialChara.chara[0]];
            }

            if (selectNum[1] == answer)
            {

                point[1] += 1;

                charaImage[1].sprite = happySprite2P[TutorialChara.chara[1]];
            }
            else
            {

                charaImage[1].sprite = sadSprite2P[TutorialChara.chara[1]];
            }
        }
    }

    //public void AnswerChack()
    //{
    //    _answer = true;
    //}

    //public void ChanceReset()
    //{

    //    AnswerChack._answer = false;
    //}

    public void FinishPoint()
    {

        TankCheck._tankCheck = false;

        PlayerPrefs.SetInt("Player1PointScore", point[0]);

        PlayerPrefs.SetInt("Player2PointScore", point[1]);
    }

    public void FinishTimer()
    {

        TankCheck._tankCheck = true;

        PlayerPrefs.SetInt("Player1TimeScore", timerCount[0]);

        PlayerPrefs.SetInt("Player2TimeScore", timerCount[1]);
    }
    IEnumerator TankTimer1()
    {

        yield return new WaitForSeconds(timeSpeed);

        if (timerObjP1[0].activeSelf)
        {

            timerCount[0] -= 1;

            timerObjP1[0].SetActive(false);

            yield return new WaitForSeconds(timeSpeed);
        }
        if (timerObjP1[1].activeSelf)
        {

            timerCount[0] -= 1;

            timerObjP1[1].SetActive(false);

            yield return new WaitForSeconds(timeSpeed);
        }
        if (timerObjP1[2].activeSelf)
        {

            timerCount[0] -= 1;

            timerObjP1[2].SetActive(false);

            yield return new WaitForSeconds(timeSpeed);
        }
        if (timerObjP1[3].activeSelf)
        {

            timerCount[0] -= 1;

            timerObjP1[3].SetActive(false);

            yield return new WaitForSeconds(timeSpeed);
        }
        if (timerObjP1[4].activeSelf)
        {

            timerCount[0] -= 1;

            timerObjP1[4].SetActive(false);
        }
        if (timerObjP1[4].activeSelf == false)
        {

            if (!_finishChack)
            {

                FinishTimer();

                _finishChack = true;

                InvokeRepeating(nameof(SceneFinish), 0.01f, 0.01f);
            }

        }

    }

    IEnumerator TankTimer2()
    {

        yield return new WaitForSeconds(timeSpeed);

        if (timerObjP2[0].activeSelf)
        {

            timerCount[1] -= 1;

            timerObjP2[0].SetActive(false);

            yield return new WaitForSeconds(timeSpeed);
        }
        if (timerObjP2[1].activeSelf)
        {

            timerCount[1] -= 1;

            timerObjP2[1].SetActive(false);

            yield return new WaitForSeconds(timeSpeed);
        }
        if (timerObjP2[2].activeSelf)
        {

            timerCount[1] -= 1;

            timerObjP2[2].SetActive(false);

            yield return new WaitForSeconds(timeSpeed);
        }
        if (timerObjP2[3].activeSelf)
        {

            timerCount[1] -= 1;

            timerObjP2[3].SetActive(false);

            yield return new WaitForSeconds(timeSpeed);
        }
        if (timerObjP2[4].activeSelf)
        {

            timerCount[1] -= 1;

            timerObjP2[4].SetActive(false);
        }
        if (timerObjP2[4].activeSelf == false)
        {

            if (!_finishChack)
            {

                FinishTimer();

                _finishChack = true;

                InvokeRepeating(nameof(SceneFinish), 0.01f, 0.01f);
            }
        }

    }

    public void StartTimer()
    {

        tankEnume[0] = null;

        tankEnume[0] = TankTimer1();

        tankEnume[1] = null;

        tankEnume[1] = TankTimer2();

        StartCoroutine(tankEnume[0]);

        StartCoroutine(tankEnume[1]);
    }

    IEnumerator FinishAnswer()
    {
        timerText.text = "3";
        yield return new WaitForSeconds(1);
        timerText.text = "2";
        yield return new WaitForSeconds(1);
        timerText.text = "1";
        yield return new WaitForSeconds(1);
        timerText.text = "";
        textScript.FinishQuestion();
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
}
