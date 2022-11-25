using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Sprite Corazon;
    public Sprite Calavera;
    private SpriteRenderer s;

    void Start()
    {
        s = GetComponent<SpriteRenderer>();
    }

    public void calavera() //Función para cambiar el Sprite a la carta calavera
    {
        s.sprite = Calavera;
    }

    public void corazon() //Función para cambiar el Sprite a la carta corazón
    {
        s.sprite = Corazon;
    }
}

