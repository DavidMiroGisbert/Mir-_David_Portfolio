using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [Header("Variables enemigo")]
    public float visionRadio;
    public float velocidad = 1.5f;

    //variable para guardar al jugadror
    GameObject objetivo;

    float maximoEnemigos;
    public float vidaEnemigo;

    //Variable para guardar la posicion inicial
    Vector3 poseInicial;

    // Start is called before the first frame update
    void Start()
    {
        //Vida de los enemigos según su tipo 
        if (gameObject.tag == "EnemigoPequeño")
        {
            vidaEnemigo = 2;
        }
        if (gameObject.tag == "EnemigoNormal")
        {
            vidaEnemigo = 4;
        }
        if (gameObject.tag == "EnemigoTocho")
        {
            vidaEnemigo = 6;
        }
        maximoEnemigos = EnemigoInstancia.enemigosMax - 1;

        objetivo = GameObject.FindGameObjectWithTag("Player");
        poseInicial = transform.position;  //guardamos la posicion inicial
    }

    // Update is called once per frame
    void Update()
    {
        //Si la distancia hasta el jugador es menor que el radio de visión, el objetivo será él
        float distancia = Vector3.Distance(objetivo.transform.position, transform.position);
        if (distancia < visionRadio)
        {
            poseInicial = objetivo.transform.position;
        }
        else //Si no, el enemigo se quedará en la última posición del jugador
        {
            transform.position = transform.position;
        }

        //El enemigo perseguirá al jugador en dirección a su target
        float movimiento_enemigo = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, poseInicial, movimiento_enemigo);
        transform.LookAt(objetivo.transform.position);

        Debug.DrawLine(transform.position, poseInicial, Color.blue);
    }

    void OnDrawGizmos() //Rango del enemigo para cuando te detecte
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadio);
    }

    void EnemigoMuerto()  //Instancia de los enemigos para que una vez destruido, instancie otro
    {
        if(vidaEnemigo > 0)
        {
            vidaEnemigo = vidaEnemigo - CanonProperties.dañoBala;
        }
        else
        {
            EnemigoInstancia.enemigosEnPantalla--;
            Debug.Log(EnemigoInstancia.enemigosEnPantalla);
            maximoEnemigos = EnemigoInstancia.enemigosMax - 1;
            Destroy(gameObject);
            PlayerController.enemigosMuertos++;
        }     
    }
    public void OnTriggerEnter(Collider other) //Cuando colisiona con el tag bala, se destruye
    {
        if (other.gameObject.tag == "Bala")
        {
            CanonProperties.balaDestruida = true;
            EnemigoMuerto();
        }
    } 
}
