using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalJuego : MonoBehaviour
{
    public Image creamFade;
    //AUDIO
    AudioSource myAudio;
    public AudioClip interfz;

    public Text texto_Click;


    //Color: E6FF00 //

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        creamFade.canvasRenderer.SetAlpha(0.0f);
        fadeOutText();
    }


    public void finalizar()
    {
        myAudio.PlayOneShot(interfz);
        fadeIn();
        Invoke("AfterPressing", 0.95f);
    }

    void fadeIn()
    {
        creamFade.CrossFadeAlpha(1, 1, false);
    }

    void fadeInText()
    {
        texto_Click.CrossFadeAlpha(1, 1, false);
        StartCoroutine("EsperaFadeIn");
    }

    void fadeOutText()
    {
        texto_Click.CrossFadeAlpha(0, 1, false);
        StartCoroutine("EsperaFadeOut");
    }

    IEnumerator EsperaFadeOut()
    {
        yield return new WaitForSeconds(1f);
        fadeInText();
    }

    IEnumerator EsperaFadeIn()
    {
        yield return new WaitForSeconds(1f);
        fadeOutText();
    }

    void AfterPressing()
    {
        SceneManager.LoadScene("MenuInicio");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
