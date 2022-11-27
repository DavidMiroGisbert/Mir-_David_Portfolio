using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoInstancia : MonoBehaviour
{
    public List<GameObject> enemigos = new List<GameObject>();
    public Transform[] posiciones;
    public static float enemigosMax;
    public static float enemigosEnPantalla;

    int tipoEnemigo;
    // Start is called before the first frame update
    void Start()
    {
        enemigosEnPantalla = 0;
        enemigosMax = 1;
        StartCoroutine("SpawnerEnemigo");
    }
    IEnumerator SpawnerEnemigo() //Tiempo de espera para que instancie el enemigo 
    {
        if (enemigosEnPantalla < enemigosMax)
        {
            enemigosEnPantalla++;
            InstanciaEnemigo();
        }

        yield return new WaitForSeconds(5f);
        StartCoroutine("SpawnerEnemigo");
        //enemigosMax = enemigosEnPantalla;
    }
    public void InstanciaEnemigo() 
    {
        int randomizarEnemigo = Random.Range(0,101); //Random que según el valor instancia un tipo de enemigo u otro

        //Probabilidades de que instancie un enemigo u otro según el modo de dificultad elegido

        //FACIL
        if (Dificultades.facil==true)
        {
            enemigosMax = 4;

            if (randomizarEnemigo>=0 && randomizarEnemigo<=50)
            {
                tipoEnemigo = 0;
            }
            else if (randomizarEnemigo >= 51 && randomizarEnemigo <= 90)
            {
                tipoEnemigo = 1;
            }
            else
            {
                tipoEnemigo = 2;
            }
        }

        //NORMAL
        else if (Dificultades.normal==true)
        {
            enemigosMax = 7;

            if (randomizarEnemigo >= 0 && randomizarEnemigo <= 40)
            {
                tipoEnemigo = 0;
            }
            else if (randomizarEnemigo >= 41 && randomizarEnemigo <= 85)
            {
                tipoEnemigo = 1;
            }
            else
            {
                tipoEnemigo = 2;
            }
        }

        //DIFÍCIL
        else if (Dificultades.dificil == true)
        {
            enemigosMax = 10;

            if (randomizarEnemigo >= 0 && randomizarEnemigo <= 33)
            {
                tipoEnemigo = 0;
            }
            else if (randomizarEnemigo >= 34 && randomizarEnemigo <= 66)
            {
                tipoEnemigo = 1;
            }
            else
            {
                tipoEnemigo = 2;
            }
        }

        //EXPERTO
        else
        {
            enemigosMax = 20;

            if (randomizarEnemigo >= 0 && randomizarEnemigo <= 9)
            {
                tipoEnemigo = 0;
            }
            else if (randomizarEnemigo >= 10 && randomizarEnemigo <= 30)
            {
                tipoEnemigo = 1;
            }
            else
            {
                tipoEnemigo = 2;
            }
        }
        //instancia de los enemigos según el tipo que sea y según la ubicación que salga mediante el random de las posiciones establecidas
        Vector3 pos = new Vector3(Random.Range(50, 100), 0, Random.Range(50,100));
        GameObject enemigoinstancia = Instantiate(enemigos[tipoEnemigo], posiciones[Random.Range(0, posiciones.Length)].position + pos, enemigos[tipoEnemigo].transform.rotation);
       
        enemigoinstancia.SetActive(true);
    }
}
