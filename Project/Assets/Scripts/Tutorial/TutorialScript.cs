using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{

    public Image mainPanelImage;

    public Sprite mainSprite;

    public ScriptableScript scriptable;

    public Text charaText;

    string words;

    string talks;

    public Image[] charaImage;

    public Sprite[] charaSprite1P;

    public Sprite[] charaSprite2P;

    bool _textCheck = true;

    int textCount = -1;

    private IEnumerator textEnume;

    public Image panelImage;

    float color;

    public Image[] keyImage1P;

    public Image[] keyImage2P;

    [Serializable]
    public class KeySpriteClass
    {

        public Sprite[] keySprite1P;

        public Sprite[] keySprite2P;
    }

    public List<KeySpriteClass> keyList;

    public GameObject countTextObj;

    Outline textOutline;

    public GameObject[] charaLight;

    public GameObject quizLight;

    public GameObject[] selectLight;

    public GameObject[] keyLight;

    public GameObject[] timerLight;

    public GameObject[] okLight;

    public AudioClip sound1;

    AudioSource audioSource;

    private void Start()
    {

        mainPanelImage.sprite = mainSprite;

        charaImage[0].sprite = charaSprite1P[TutorialChara.chara[0]];

        charaImage[1].sprite = charaSprite2P[TutorialChara.chara[1]];

        textEnume = Text();

        for(int i = 0; i < 4; i++)
        {

            keyImage1P[i].sprite = keyList[TutorialChara.chara[0]].keySprite1P[i];

            keyImage2P[i].sprite = keyList[TutorialChara.chara[1]].keySprite2P[i];
        }

        textOutline = countTextObj.GetComponent<Outline>();

        textOutline.enabled = false;

        quizLight.SetActive(false);

        for(int i = 0; i < 2; i++)
        {

            charaLight[i].SetActive(false);

            timerLight[i].SetActive(false);

            okLight[i].SetActive(false);
        }

        for(int i = 0; i < 4; i++)
        {

            selectLight[i].SetActive(false);
        }

        for(int i = 0; i < 8; i++)
        {

            keyLight[i].SetActive(false);
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (textCount == 11)
            {

                audioSource.PlayOneShot(sound1);

                InvokeRepeating(nameof(SceneFinish), 0.01f, 0.01f);

                return;
            }

            if (_textCheck)
            {
                textCount += 1;

                talks = scriptable.tutorialText[textCount];

                textEnume = null;

                textEnume = Text();

                StartCoroutine(textEnume);

                audioSource.PlayOneShot(sound1);
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

                if (textCount == 10) textCount += 1;

                _textCheck = true;
            }

            if (textCount == 1)
            {

                for (int i = 0; i < 2; i++)
                {

                    charaLight[i].SetActive(true);
                }
            }

            if(textCount == 2)
            {

                quizLight.SetActive(true);

                for (int i = 0; i < 2; i++)
                {

                    charaLight[i].SetActive(false);
                }
            }

            if(textCount == 3)
            {

                quizLight.SetActive(false);

                textOutline.enabled = true;
            }

            if(textCount == 4)
            {

                textOutline.enabled = false;

                for (int i = 0; i < 4; i++)
                {

                    selectLight[i].SetActive(true);
                }
            }

            if(textCount == 5)
            {

                for (int i = 0; i < 4; i++)
                {

                    selectLight[i].SetActive(false);
                }

                for (int i = 0; i < 8; i++)
                {

                    keyLight[i].SetActive(true);
                }
            }

            if(textCount == 7)
            {

                for (int i = 0; i < 8; i++)
                {

                    keyLight[i].SetActive(false);
                }

                for (int i = 0; i < 2; i++)
                {

                    timerLight[i].SetActive(true);

                    okLight[i].SetActive(true);
                }
            }

            if(textCount == 10)
            {

                for (int i = 0; i < 2; i++)
                {

                    timerLight[i].SetActive(false);

                    okLight[i].SetActive(false);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {

            InvokeRepeating(nameof(SceneFinish), 0.01f, 0.01f);
        }
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

    void SceneFinish()
    {
        if (color <= 1)
        {

            color += Time.deltaTime * 2;

            panelImage.color = new Color(color, color, color, color);
        }
        else
        {

            color = 1;

            panelImage.color = new Color(color, color, color, color);

            SceneManager.LoadScene("MaineScene");
        }
    }
}
