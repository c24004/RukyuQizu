using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartScript : MonoBehaviour
{

    float color;

    public Image panelImage;

    public AudioClip sound1;

    AudioSource audioSource;

    private void Start()
    {

        color = 1;

        panelImage.color = new Color(color, color, color, color);

        InvokeRepeating(nameof(PanelImage), 0.01f, 0.01f);

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            InvokeRepeating(nameof(SceneFinish), 0.01f, 0.01f);

            audioSource.PlayOneShot(sound1);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Application.Quit();
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
    void SceneFinish()
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
            SceneManager.LoadScene("TitleScene");
        }
    }
}
