using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoAlien : MonoBehaviour
{
    public float fuerzabala = -3f;
    Rigidbody Balarb;
    float timeAux;
    public GameObject bala;
    // Start is called before the first frame update
    void Start()
    {
        timeAux = Time.time;
        StartCoroutine("disparo");
    }

    private IEnumerator disparo()
    {
        yield return new WaitForSeconds(3f); //Cada 3 segundos, los aliens harán un random para ver si realizan un disparo o no
        int random = Random.Range(1, 101);
        float timeDif = Time.time - timeAux;

        if (random < 20) //En caso de que el random sea menor a 20, el alien generará un disparo
        {
            //Instanciamiento de las balas de los aliens
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject clon = Instantiate(bala, pos, Quaternion.identity) as GameObject;
            clon.SetActive(true);

            Balarb = clon.GetComponent<Rigidbody>();
            Vector3 direccionbala = new Vector3(0, fuerzabala, 0);
            Balarb.AddForce(direccionbala);
            timeAux = Time.time;
        }
        StartCoroutine("disparo"); //Repite el proceso para ver si realiza el disparo
    }
}
