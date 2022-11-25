using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bala : MonoBehaviour
{
    
    public float velocidad = 20f; //Velocidad de la bala
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestruirBala());
    }

    // Update is called once per frame
    void Update()
    {
        float vY = velocidad * Time.deltaTime; //Movimiento bala
        transform.Translate(0, vY, 0);
    }
    public void OnTriggerEnter(Collider collision) //Destruye la bala al chocar con el límite superior o al destruir un alien
    {
        
        if (collision.gameObject.tag == "Finish")
        {
            Disparo.disparar = true;
            Destroy(gameObject);
            
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Disparo.disparar = true;
            Destroy(gameObject);
            ContadorMuertes.score++; //Suma uno al contador cada vez que muere un alien
        }
    }
   
    IEnumerator DestruirBala() //Destrucción de la bala por si no detecta la colisión con el límite
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        Disparo.disparar = true;
    }
}
