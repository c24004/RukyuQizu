using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class TutorialChara
{

    public static int[] chara = {0,1};

    //public static int charaP2 = 1;
}

public class SelectScript : MonoBehaviour
{

    public Image panelImage;

    float color;

    public Image[] charaSelectImage;

    public Text selectText;

    //private readonly string sameText = "‚±‚ÌƒLƒƒƒ‰‚Í‘I‘ð‚³‚ê‚Ü‚µ‚½";

    //private readonly string moreText = "‚ ‚È‚½‚Í‚±‚ÌƒLƒƒƒ‰‚Å‚·";

    private string defaultText;

    private IEnumerator selectEnume;

    public GameObject[] selectObj;

    public Sprite[] selectSprite;

    public GameObject tutorialObj;

    public GameObject selectManager;

    public GameObject[] charaObj;

    public Image[] charaImage;

    public Sprite[] charaSprite;

    private bool _selectCheck = true;

    void Start()
    {

        TutorialChara.chara[0] = 0;

        TutorialChara.chara[1] = 3;

        selectEnume = Select();

        defaultText = selectText.text;

        selectObj[1].SetActive(false);

        selectObj[2].SetActive(false);

        StartCoroutine(selectEnume);

        color = 1;

        panelImage.color = new Color(color, color, color, color);

        InvokeRepeating(nameof(PanelImage), 0.01f, 0.01f);
    }

    void Update()
    {

        if (_selectCheck)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {

                if (TutorialChara.chara[0] == 0) return;
                if (TutorialChara.chara[0] == 1 && TutorialChara.chara[1] == 0) return;
                PlayerSelect(-1, 0, 1);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {

                if (TutorialChara.chara[0] == 3) return;
                if (TutorialChara.chara[0] == 2 && TutorialChara.chara[1] == 3) return;
                PlayerSelect(1, 0, 1);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                if (TutorialChara.chara[1] == 0) return;
                if (TutorialChara.chara[1] == 1 && TutorialChara.chara[0] == 0) return;
                PlayerSelect(-1, 1, 0);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                if (TutorialChara.chara[1] == 3) return;
                if (TutorialChara.chara[1] == 2 && TutorialChara.chara[0] == 3) return;
                PlayerSelect(1, 1, 0);
            }
        }
    }

    IEnumerator Select()
    {

        selectText.text = "20";
        yield return new WaitForSeconds(1);
        selectText.text = "19";
        yield return new WaitForSeconds(1);
        selectText.text = "18";
        yield return new WaitForSeconds(1);
        selectText.text = "17";
        yield return new WaitForSeconds(1);
        selectText.text = "16";
        yield return new WaitForSeconds(1);
        selectText.text = "15";
        yield return new WaitForSeconds(1);
        selectText.text = "14";
        yield return new WaitForSeconds(1);
        selectText.text = "13";
        yield return new WaitForSeconds(1);
        selectText.text = "12";
        yield return new WaitForSeconds(1);
        selectText.text = "11";
        yield return new WaitForSeconds(1);
        selectText.text = "10";
        yield return new WaitForSeconds(1);
        selectText.text = "9";
        yield return new WaitForSeconds(1);
        selectText.text = "8";
        yield return new WaitForSeconds(1);
        selectText.text = "7";
        yield return new WaitForSeconds(1);
        selectText.text = "6";
        yield return new WaitForSeconds(1);
        selectText.text = "5";
        yield return new WaitForSeconds(1);
        selectText.text = "4";
        yield return new WaitForSeconds(1);
        selectText.text = "3";
        yield return new WaitForSeconds(1);
        selectText.text = "2";
        yield return new WaitForSeconds(1);
        selectText.text = "1";
        yield return new WaitForSeconds(1);
        _selectCheck = false;
        selectText.text = "0";
        for(int i = 0; i < 4; i++)
        {

            if(i != TutorialChara.chara[0] && i != TutorialChara.chara[1])
            {

                charaObj[i].SetActive(false);
            }
        }

        yield return new WaitForSeconds(3);
        selectManager.SetActive(false);
        tutorialObj.SetActive(true);
    }

    

    //IEnumerator SameSelection()
    //{

    //    selectText.text = sameText;

    //    yield return new WaitForSeconds(1);

    //    selectText.text = defaultText;
    //}

    //IEnumerator MoreSelection()
    //{

    //    selectText.text = moreText;

    //    yield return new WaitForSeconds(1);

    //    selectText.text = defaultText;
    //}

    //void Player1Select(int selectNum0, int selectNum1, int selectNum2, int selectNum3, int playerNum1, int playerNum2)
    //{

    //    if (TutorialChara.chara[playerNum2] != selectNum0)
    //    {

    //        if (TutorialChara.chara[playerNum1] == selectNum1)
    //        {

    //            charaImage[selectNum0].sprite = selectSprite[playerNum1];

    //            selectObj[selectNum1].SetActive(false);

    //            selectObj[selectNum0].SetActive(true);

    //            TutorialChara.chara[playerNum1] = selectNum0;
    //        }
    //        else if (TutorialChara.chara[playerNum1] == selectNum2)
    //        {

    //            charaImage[selectNum0].sprite = selectSprite[playerNum1];

    //            selectObj[selectNum2].SetActive(false);

    //            selectObj[selectNum0].SetActive(true);

    //            TutorialChara.chara[playerNum1] = selectNum0;
    //        }
    //        else if (TutorialChara.chara[playerNum1] == selectNum3)
    //        {

    //            charaImage[selectNum0].sprite = selectSprite[playerNum1];

    //            selectObj[selectNum3].SetActive(false);

    //            selectObj[selectNum0].SetActive(true);

    //            TutorialChara.chara[playerNum1] = selectNum0;
    //        }
    //        else
    //        {

    //            StartCoroutine(MoreSelection());
    //        }
    //    }
    //    else
    //    {

    //        StartCoroutine(SameSelection());
    //    }
    //}

    void PlayerSelect(int point,int player1Num,int player2Num)
    {

        if (TutorialChara.chara[player1Num] + point == TutorialChara.chara[player2Num])
        {

            point *= 2;

            TutorialChara.chara[player1Num] += point;

            charaSelectImage[TutorialChara.chara[player1Num]].sprite = selectSprite[player1Num];

            selectObj[TutorialChara.chara[player1Num] - point].SetActive(false);

            selectObj[TutorialChara.chara[player1Num]].SetActive(true);
        }
        else
        {

            TutorialChara.chara[player1Num] += point;

            charaSelectImage[TutorialChara.chara[player1Num]].sprite = selectSprite[player1Num];

            selectObj[TutorialChara.chara[player1Num] - point].SetActive(false);

            selectObj[TutorialChara.chara[player1Num]].SetActive(true);
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

            CancelInvoke(nameof(PanelImage));
        }
    }
}


