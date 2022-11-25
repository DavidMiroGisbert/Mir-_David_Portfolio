using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float vidaI;
    public float vidaR;
    public int velocidad;
    public int ataque;

    public Enemigo(float vidaI, float vidaR, int ataque)
    {
        this.vidaI = vidaI;
        this.vidaR = vidaR;
        this.ataque = ataque;
    }
}
