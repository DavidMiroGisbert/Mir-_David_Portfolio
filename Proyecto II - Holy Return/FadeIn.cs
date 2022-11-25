using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FadeIn : MonoBehaviour
{
    public Image blackFade;
    public Button continuar;
    public Text historia;

    bool butnoff = false;
    string activetext;

    public float Speed;

    //AUDIO
    AudioSource myAudio;
    public AudioClip interfz;
    // Start is called before the first frame update
    void Start()
    {
        activetext = "Erase una vez un humano, un vater y un destino. En las afueras de la ciudad se encontraba un humano en un dia de verano. Tras varias revoluciones industriales comenzaba a desarrollarse una evolucion en la sociedad. Tras un dia duro de trabajo en la fabrica, regresaba a comer y descansar a su casa.  Sin embargo, tras digerir cierto alimento, su estomago comenzo a darle problemas, es aqui cuando el humano acude al baño y comienza la odisea de la creacion. Un nuevo ser estaba a punto de cobrar vida... Nuestro querido e inocente Martin Hez, quien tratara de darle sentido a su vida.";
        historia.text = activetext;
        continuar.gameObject.SetActive(false);
        myAudio = GetComponent<AudioSource>();
        blackFade.canvasRenderer.SetAlpha(1.0f);
        fadeOut();
        StartCoroutine(EfectoLetra(activetext));
        StartCoroutine(mostrarBoton());
        
    }


    void fadeIn()
    {
        blackFade.CrossFadeAlpha(1, 1, false);
    }
    void fadeOut()
    {
        blackFade.CrossFadeAlpha(0, 1, false);
    }

    public void Continuar()
    {
        myAudio.PlayOneShot(interfz);
        butnoff = true;
        fadeIn();
        Invoke("AfterPressing", 1f);
        activetext = "";
        continuar.gameObject.SetActive(false);
        
    }

    void AfterPressing()
    {
        SceneManager.LoadScene("MenuInicio");
    }

    IEnumerator EfectoLetra(string sentence) //Se muestran las letras 1 a 1 efecto retro
    {
        historia.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            historia.text += letter;
            myAudio.PlayOneShot(interfz); //Sonido por letra
            yield return new WaitForSeconds(Speed);
        }

    }

    IEnumerator mostrarBoton()
    {
        
        yield return new WaitForSeconds(6f);
        continuar.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
