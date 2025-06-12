using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class TankCheck
{

    public static bool _tankCheck;
}

public class ResultScript : MonoBehaviour
{

    public Text winnerText;

    public Image[] charaImage;

    public GameObject[] charaObj;

    public Sprite[] panelSprites;

    public Sprite[] rightDrawSprite;

    public Sprite[] leftDrawSprite;

    void Start()
    {

        int player1Timer = PlayerPrefs.GetInt("Player1TimeScore");
        int player2Timer = PlayerPrefs.GetInt("Player2TimeScore");

        int player1Point = PlayerPrefs.GetInt("Player1PointScore");
        int player2Point = PlayerPrefs.GetInt("Player2PointScore");

        if (TankCheck._tankCheck)
        {

            if (player1Timer > player2Timer)
            {

                winnerText.text = "Player1";

                charaImage[0].sprite = panelSprites[TutorialChara.chara[0]];

                charaObj[1].SetActive(false);
            }
            else if (player2Timer > player1Timer)
            {

                winnerText.text = "Player2";

                charaImage[1].sprite = panelSprites[TutorialChara.chara[1]];

                charaObj[0].SetActive(false);
            }
        }
        else
        {

            if (player1Point > player2Point)
            {

                winnerText.text = "Player1";

                charaImage[0].sprite = panelSprites[TutorialChara.chara[0]];

                charaObj[1].SetActive(false);
            }
            else if (player2Point > player1Point)
            {

                winnerText.text = "Player2";

                charaImage[1].sprite = panelSprites[TutorialChara.chara[1]];

                charaObj[0].SetActive(false);
            }
            else
            {

                if (player1Timer > player2Timer)
                {

                    winnerText.text = "Player1";

                    charaImage[0].sprite = panelSprites[TutorialChara.chara[0]];

                    charaObj[1].SetActive(false);
                }
                else if (player2Timer > player1Timer)
                {

                    winnerText.text = "Player2";

                    charaImage[1].sprite = panelSprites[TutorialChara.chara[1]];

                    charaObj[0].SetActive(false);
                }
                else
                {

                    winnerText.text = "Draw";

                    charaImage[0].sprite = leftDrawSprite[TutorialChara.chara[0]];

                    charaImage[1].sprite = rightDrawSprite[TutorialChara.chara[1]];
                }
            }
        }
    }
}
