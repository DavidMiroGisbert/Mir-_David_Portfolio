using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vidas : MonoBehaviour
{
    public float vidas=3; //Las vidas del jugador que estarán inicializadas a 3
    public Text VidasText;
    public Image Imagen;
    public Text GameOver;
    public Button reiniciar;
    // Start is called before the first frame update
    void Start()
    {
        GameOver.enabled = false;
        Imagen.enabled = false;
        VidasText.text = "Vidas: " + vidas;
    }
    private void OnTriggerEnter(Collider impacto)
    {
        if (impacto.gameObject.tag == "Player") //Cada vez que le de una bala se le restará una vida al jugador
        {
            vidas--;
            VidasText.text = "Vidas: " + vidas;
        }
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (vidas==0)  //En el caso de que el jugador se quede sin vidas se mostrará por pantalla que ha perdido
        {
            reiniciar.gameObject.SetActive(true);
            GameOver.enabled = true;
            Imagen.enabled = true;
        }
    }
    public void Restart() //Funcion para volver a cargar el juego
    {
        SceneManager.LoadScene("SampleScene");

    }
}
