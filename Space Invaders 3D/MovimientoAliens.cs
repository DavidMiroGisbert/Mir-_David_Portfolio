using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAliens : MonoBehaviour
{
    float x;


    float velocidad;


    void Start() //Posicion inicio
    {
        x = 3f;


        velocidad = 1f;

    }

    void Update()
    {
        transform.Translate(x * Time.deltaTime, 0, 0); //Movimiento alien
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "derecha") //Al colisionar con el límite derecho o izquierdo, cambia la dirección y baja el alien, además, la velocidad aumenta a cada vez que colisiona
        {
            transform.Translate(x * Time.deltaTime, -3f, 0);

            x = -3f;

            velocidad = velocidad + 0.6f;

            x = x - velocidad;
        }

        if (collision.gameObject.tag == "izquierda")
        {
            transform.Translate(x * Time.deltaTime, -3f, 0);


            x = 3f;

            velocidad = velocidad + 0.6f;

            x = x + velocidad;
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag=="Finish") //Al llegar al límite inferior se destruyen los GameObjects de los Aliens
        {
            Destroy(gameObject);
        }
    }
}