using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirBalasEnemigos : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine("DestruirBala");
    }
    IEnumerator DestruirBala()  //Una vez pasa 5 segundos, la bala se destruye automáticamente
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
