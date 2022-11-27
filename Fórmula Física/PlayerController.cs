using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("movimiento")]
    public float velocidad = 5.0f;
    
    public float gravedad = 9.8f;


    [Header("Vida Personaje")]
    public Text VidaPersonaje;
    public static float vida ;
    public static float VidaMax;
    public static float enemigosMuertos;
    public static float tiempoRecord;

    bool recoilVida = true;
    int tipoEnemigo;
    int tipoBala;

   //Setear la vida inicial
    void Start()
    {
        vidaDificultades();
        VidaPersonaje.text = VidaMax.ToString();

    }

    // Muerte
    void Update()
    {
        if (vida<=0)
        {
            vida = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    //Vida del personaje en función de dificultad
    public void vidaDificultades()
    {
        if (Dificultades.facil == true)
        {
            VidaMax = 1000;
            vida = VidaMax;
        }
        else if (Dificultades.normal == true)
        {
            VidaMax = 800;
            vida = VidaMax;
        }
        else if (Dificultades.dificil == true)
        {
            VidaMax = 600;
            vida = VidaMax;
        }
        else
        {
            VidaMax = 400;
            vida = VidaMax;
        }
    }


    //Cadencia de daño
    IEnumerator RecoilRestarVida()
    {
        recoilVida = false;
        yield return new WaitForSeconds(2f);
        recoilVida = true;      
    }


    //Disminuir vida en función de dificultad
    void RestarVida()
    {
        if (recoilVida==true && tipoEnemigo==1)
        {
            vida = vida - 30;
            VidaPersonaje.text = " " + vida;
            StartCoroutine("RecoilRestarVida");
        }
        else if (recoilVida == true && tipoEnemigo == 2)
        {
            vida = vida - 50;
            VidaPersonaje.text = " " + vida;
            StartCoroutine("RecoilRestarVida");
        }
        else if (recoilVida == true && tipoEnemigo == 3)
        {
            vida = vida - 70;
            VidaPersonaje.text = " " + vida;
            StartCoroutine("RecoilRestarVida");
        }
        else if ( tipoBala == 1)
        {
            vida = vida - 15;
            VidaPersonaje.text = " " + vida;         
        } 
        else if (tipoBala == 2)
        {
            vida = vida - 25;
            VidaPersonaje.text = " " + vida;         
        }
        
        else if ( tipoBala == 3)
        {
            vida = vida - 30;
            VidaPersonaje.text = " " + vida;          
        }
        else if ( tipoBala == 4)
        {
            vida = vida - 35;
            VidaPersonaje.text = " " + vida;
           
        }
    }
     
    //Colisiones contra enemigos
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemigoPequeño" && recoilVida==true)
        {
            tipoEnemigo = 1;
            RestarVida();
            print("Tocado");           
        }

       if (other.gameObject.tag == "EnemigoNormal" && recoilVida==true)
       {
            tipoEnemigo = 2;
            RestarVida();
       }


        if (other.gameObject.tag == "EnemigoTocho" && recoilVida==true)
        {
            tipoEnemigo = 3;
            RestarVida();
        }


        //Collisiones de Bala
        if (other.gameObject.tag == "Bullet1" && recoilVida == true)
        {
            tipoBala = 1;
            RestarVida();
            print(vida);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Bullet2" && recoilVida == true)
        {
            tipoBala = 2;
            RestarVida();
            print(vida);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Bullet3" && recoilVida == true)
        {
            tipoBala = 3;
            RestarVida();
            print(vida);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Bullet4" && recoilVida == true)
        {
            tipoBala = 4;
            RestarVida();
            print(vida);
            Destroy(other.gameObject);
        }

        //Recolección de power up
        if(other.gameObject.tag == "Vida" && vida < VidaMax)
        {
            vida += 50;
            VidaPersonaje.text = " " + vida;
            Destroy(other.gameObject);
        }

        

        if(other.gameObject.tag == "Prueba")
        {
            vida -= 10;
            VidaPersonaje.text = " " + vida;
        }

    }
}
