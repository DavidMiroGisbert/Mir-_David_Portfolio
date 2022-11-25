using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card3 : MonoBehaviour
{
    public Sprite Corazon;
    public Sprite Calavera;
    bool cambio = false;
    private SpriteRenderer s;

    void Awake()
    {
        s = GetComponent<SpriteRenderer>();
    }


    public void calavera() //Función para cambiar el Sprite a la carta calavera
    {
        cambio = true;
        if (cambio == true)
        {
            s.sprite = Calavera;
            cambio = false;
        }

    }

    public void corazon() //Función para cambiar el Sprite a la carta corazón
    {
        cambio = true;
        if (cambio == true)
        {
            s.sprite = Corazon;
            cambio = false;
        }
    }
}
