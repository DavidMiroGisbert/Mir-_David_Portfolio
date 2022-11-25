using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Transform posicion;
    public Text intro;
    public GameObject Alien;
    // Start is called before the first frame update
    void Start()
    {
        intro.text = "Preparate para defender la Tierra";
        StartCoroutine("cinematica"); //Coroutine que nos mostrará un texto a modo de "cinemática"
        posicion = GetComponent<Transform>();
    }

    void Instanciar() //Instancia el grupo de aliens cada vez que se llama a la función
    {
        for (int x = -26; x < 30; x=x+4)
        {
            Vector3 position = new Vector3(x, transform.position.y+9f, transform.position.z);
            GameObject clon = Instantiate(Alien, position, Quaternion.identity) as GameObject;
            clon.SetActive(true);
        }
    }
    private IEnumerator cinematica()
    {
        yield return new WaitForSeconds(2.5f);
        intro.enabled = false;
        Instanciar();
        StartCoroutine("repeticion");
    }
    private IEnumerator repeticion() //Cada 19 segundos llama a Instanciar para generar nuevos grupos de aliens
        {
        StopCoroutine("cinematica");
        int stop = 0;

         while (stop<=2)
         {
             yield return new WaitForSeconds(19f);
             Instanciar();
             if (stop == 2)
             {
                 StopCoroutine("repeticion");
             }
             stop++;
         }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
