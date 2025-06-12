using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestScript : MonoBehaviour
{
    public GameObject textObj;

    public GameObject charaImage;

    public Text charaText;

    string words;

    string talks;

    int textCount = -1;

    bool _textCheck = true;

    public Image panelImage;

    float color;

    public ScriptableScript scriptable;

    public GameObject textImageObj;

    public GameObject[] imageObj;

    public GameObject[] keyTextObj;

    public GameObject[] tankImageObj;

    //private string[] keyTextString = {null,null,null,null,null};

    public Text[] keyText;

    private IEnumerator textEnume;

    private void Start()
    {

        color = 1;

        panelImage.color = new Color(color, color, color, color);

        InvokeRepeating(nameof(PanelImage), 0.01f, 0.01f);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (textCount <= 15 && color == 0)
            {

                if (textCount == 15) _textCheck = false;

                if (_textCheck)
                {

                    textCount += 1;

                    talks = scriptable.tutorialText[textCount];

                    textEnume = null;

                    textEnume = Text();

                    StartCoroutine(textEnume);

                    _textCheck = false;
                }
                else
                {

                    string talkText = "";

                    StopCoroutine(textEnume);

                    foreach (char word in talks)
                    {

                        if (word == '_')
                        {

                            talkText += "\n";
                        }
                        else
                        {

                            talkText += word;
                        }
                    }

                    charaText.text = talkText;

                    _textCheck = true;

                    if (textCount == 15) textCount += 1;
                }


                if (textCount == 5) textImageObj.SetActive(true);

                if (textCount == 10)
                {
                    imageObj[0].SetActive(false);

                    for (int i = 1; i <= 4; i++)
                    {

                        imageObj[i].SetActive(true);
                    }

                    for (int i = 0; i <= 4; i++)
                    {

                        keyTextObj[i].SetActive(true);
                    }

                    keyText[0].text = "P1";
                    keyText[1].text = "Q";
                    keyText[2].text = "W";
                    keyText[3].text = "A";
                    keyText[4].text = "S";
                }

                if (textCount == 11)
                {
                    keyText[0].text = "P2";
                    keyText[1].text = "I";
                    keyText[2].text = "O";
                    keyText[3].text = "K";
                    keyText[4].text = "L";
                }

                if (textCount == 12)
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        imageObj[i].SetActive(false);
                    }

                    for (int i = 0; i <= 3; i++)
                    {
                        keyTextObj[i].SetActive(false);
                    }

                    for (int i = 0; i <= 4; i++)
                    {

                        tankImageObj[i].SetActive(true);
                    }
                }

                if (textCount == 14)
                {
                    for (int i = 0; i <= 4; i++)
                    {

                        tankImageObj[i].SetActive(false);
                    }
                }

            }
            else if (textCount == 16)
            {

                textObj.SetActive(false);

                charaImage.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (textCount >= 0 && color == 0)
            {

                if (textCount == 0) _textCheck = false;

                if (_textCheck)
                {

                    textCount -= 1;

                    talks = scriptable.tutorialText[textCount];

                    textEnume = null;

                    textEnume = Text();

                    StartCoroutine(textEnume);
                }
                else
                {

                    string talkText = "";

                    StopCoroutine(textEnume);

                    foreach (char word in talks)
                    {

                        if (word == '_')
                        {

                            talkText += "\n";
                        }
                        else
                        {

                            talkText += word;
                        }
                    }

                    charaText.text = talkText;

                    _textCheck = true;
                }

                if (textCount == 13)
                {
                    for (int i = 0; i <= 4; i++)
                    {

                        tankImageObj[i].SetActive(false);
                    }
                }

                if (textCount == 11)
                {

                    for (int i = 5; i <= 9; i++)
                    {
                        imageObj[i].SetActive(false);
                    }

                    for (int i = 0; i <= 3; i++)
                    {
                        keyTextObj[i].SetActive(true);
                    }

                    for (int i = 1; i <= 4; i++)
                    {
                        imageObj[i].SetActive(true);
                    }
                }

                if (textCount == 10)
                {

                    //for (int i = 0; i <= 3; i++)
                    //{
                    //    keyTextObj[i].SetActive(false);
                    //}
                }

                if (textCount == 9)
                {

                    for (int i = 1; i <= 4; i++)
                    {
                        imageObj[i].SetActive(false);
                    }

                    for (int i = 0; i <= 3; i++)
                    {
                        keyTextObj[i].SetActive(false);
                    }

                    textImageObj.SetActive(true);
                }

                if (textCount == 4)
                {
                    textImageObj.SetActive(false);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {

            if (color == 0)
            {

                textObj.SetActive(false);

                charaImage.SetActive(true);
            }
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log(textCount);
        //}

    }

    IEnumerator Text()
    {

        charaText.text = "";

        words = talks;

        _textCheck = false;

        foreach (char word in words)
        {

            string enterString = "\n";

            if (word == '_')
            {

                charaText.text += enterString;
            }
            else
            {

                charaText.text += word;
                yield return new WaitForSeconds(0.1f);
            }
        }

        _textCheck = true;

        yield break;
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
