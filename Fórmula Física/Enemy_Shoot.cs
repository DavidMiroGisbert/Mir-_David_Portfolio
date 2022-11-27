using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour
{
    // Player
    public GameObject Target;

    // Tipos bala
    public Rigidbody Bullet1;
    public Rigidbody Bullet2;
    public Rigidbody Bullet3;
    public Rigidbody Bullet4;
    float tiempoDisparo;

    Rigidbody ActualBullet;
    float speed;

    List<Rigidbody> Projectiles = new List<Rigidbody>();
    public GameObject Spawner;


    private void Start()
    {
        // añadir los tipos de bala a una lista
        Projectiles.Add(Bullet1);
        Projectiles.Add(Bullet2);
        Projectiles.Add(Bullet3);
        Projectiles.Add(Bullet4);
        //Cadencia de disparo
        StartCoroutine("Disparo");
    }
    void Update()
    {
        //Rotación orientada a perosnaje
        transform.LookAt(Target.transform);
    }

    IEnumerator Disparo ()
    {
        //Según el tipo de dificultad  cambian los tipos de proyectil
        if (Dificultades.facil == true)
        {
            ActualBullet = Projectiles[0];
            speed = 10f;
            tiempoDisparo = 13f;

        }
        if (Dificultades.normal == true)
        {
            ActualBullet = Projectiles[1];
            speed = 100f;
            tiempoDisparo = 10f;
        }
        if (Dificultades.dificil == true)
        {
            ActualBullet = Projectiles[2];
            speed = 150f;
            tiempoDisparo = 9f;

        }
        if (Dificultades.experto == true)
        {
            ActualBullet = Projectiles[3];
            speed = 200f;
            tiempoDisparo = 7f;
        }
        yield return new WaitForSeconds(tiempoDisparo);
        // Aplicar movimiento a las balas

        Vector3 Vo = CalculateVelocity(Target.transform.position, Spawner.transform.position, 1f);
        
        Rigidbody clon = Instantiate(ActualBullet, Spawner.transform.position, Quaternion.identity);
        clon.velocity = Vo;
        StartCoroutine("Disparo");
    }

    //Cálculo de trayectoria hacia personaje para ir hacia él
    Vector3 CalculateVelocity (Vector3 target, Vector3 origin, float time)
    {

        
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 5f;

        float Sy = distance.y ;
        float Sxz = distanceXZ.magnitude;

        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz + speed;
        result.y = Vy;

        return result;
    }
        
    }
