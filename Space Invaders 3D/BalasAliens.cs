using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasAliens : MonoBehaviour
{
    public float velocidad = -5.2f; //Velocidad de la bala del alien

    void Start()
    {
        StartCoroutine(DestruirBala());
    }

    void Update()
    {
        float vY = velocidad * Time.deltaTime;
        transform.Translate(0, vY, 0);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Finish") //Al entrar por el trigger inferior destruye la bala del alien
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Barra") //Al entrar por el trigger inferior destruye la bala del alien
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Clon") //Al entrar por el trigger inferior destruye la bala del alien
        {
            Destroy(gameObject);
        }
    }
    IEnumerator DestruirBala() //Destrucción de la bala por si no detecta la colisión con el límite
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        Disparo.disparar = true;
    }
}
