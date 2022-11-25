using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objetos : MonoBehaviour
{
    public int [] objetos_lista = new int [4];

    public GameObject CanvasObjetos;
    public GameObject Jugador;
    CharacterController ComponentesJugador;
    public GameObject Ataques;
    CombatManager NumeroAtaques;
    public bool CanvasActivo;
    public Text TextRestos;
    public Text TextBanqueteRestos;
    public Text TextUltraRestos;
    public Text TextMaspp;


    //AUDIO
    AudioSource myAudio;
    public AudioClip Usaritem;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        CanvasActivo = false;
        CanvasObjetos.SetActive(false);
        ComponentesJugador = Jugador.GetComponent<CharacterController>();
        NumeroAtaques = Ataques.GetComponent<CombatManager>();
        objetos_lista[0] = 2;
        objetos_lista[1] = 2;
        objetos_lista[2] = 2;
        objetos_lista[3] = 2;
    }

    // Update is called once per frame
    void Update()
    {
        TextRestos.text = "" + objetos_lista[0];
        TextBanqueteRestos.text = "" + objetos_lista[1];
        TextUltraRestos.text = "" + objetos_lista[2];
        TextMaspp.text = "" + objetos_lista[3];
    }

    public void BotonObjetos()
    {
        if (CanvasActivo == false)
        {
            CanvasObjetos.SetActive(true);
            CanvasActivo = true;
        }
        else if (CanvasActivo == true)
        {
            CanvasObjetos.SetActive(false);
            CanvasActivo = false;
        }

    }

    public void Restos()
    {
        
        if (objetos_lista[0] != 0)
        {
            myAudio.PlayOneShot(Usaritem);
            if (ComponentesJugador.health + 50 < ComponentesJugador.Maxhealth)
            {
                ComponentesJugador.health = ComponentesJugador.health + 50;
            }
            else
            {
                ComponentesJugador.health = ComponentesJugador.Maxhealth;
            }

            objetos_lista[0]--;
        }  
    }


    public void BanqueteDeRestos()
    {
        
        if (objetos_lista[1] != 0)
        {
            myAudio.PlayOneShot(Usaritem);
            if (ComponentesJugador.health + 100 < ComponentesJugador.Maxhealth)
            {
                ComponentesJugador.health = ComponentesJugador.health + 100;
            }
            else
            {
                ComponentesJugador.health = ComponentesJugador.Maxhealth;
            }

            objetos_lista[1]--;
        }
        
    }


    public void UltraRestos()
    {
        
        if (objetos_lista[2] != 0)
        {
            myAudio.PlayOneShot(Usaritem);
            ComponentesJugador.health = ComponentesJugador.Maxhealth;
            objetos_lista[2]--;
        }
    }

    public void MasPPplus()
    {
        
        if (objetos_lista[3] != 0)
        {
            myAudio.PlayOneShot(Usaritem);
            //Ataque Normal

            if (NumeroAtaques.NumeroDeAtaquesNormales  == 0)
            {
                NumeroAtaques.botonesAccion[0].interactable = true;
            }
            if (NumeroAtaques.NumeroDeAtaquesNormales <= 15)
            {
                NumeroAtaques.NumeroDeAtaquesNormales = NumeroAtaques.NumeroDeAtaquesNormales + 10;
            }
            else
            {
                NumeroAtaques.NumeroDeAtaquesNormales = 25;
            }

            //Ataque con Garra
            if (NumeroAtaques.NumeroDeAtaquesConGarra == 0)
            {
                NumeroAtaques.botonesAccion[3].interactable = true;
            }
            if (NumeroAtaques.NumeroDeAtaquesConGarra <= 5)
            {
                NumeroAtaques.NumeroDeAtaquesConGarra = NumeroAtaques.NumeroDeAtaquesConGarra + 10;
            }
            else
            {
                NumeroAtaques.NumeroDeAtaquesConGarra = 15;
            }

            //Plumas de Dios
            if (NumeroAtaques.NumeroDePlumasDeDios == 0)
            {
                NumeroAtaques.botonesAccion[4].interactable = true;
            }
            NumeroAtaques.NumeroDePlumasDeDios = 10;

            //Lluvia Acida
            if (NumeroAtaques.NumeroDeLluviaAcida == 0)
            {
                NumeroAtaques.botonesAccion[5].interactable = true;
            }
            NumeroAtaques.NumeroDeLluviaAcida = 5;
            
            objetos_lista[3]--;
        }
        
    }

    public void DropEnemigos()
    {
        int DropEnemigo = Random.Range(0, 2);
        objetos_lista[DropEnemigo]++;
    }
}
