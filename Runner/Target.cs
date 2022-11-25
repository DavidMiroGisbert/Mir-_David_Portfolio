using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target); //Fijación del objetivo
        if (target==true)
        {
            StartCoroutine("OtroTarget");
        }
    }
    IEnumerator OtroTarget()//Courutine para que se destruya el proyectil a los 3segs. si no golpea al objetivo
    { 
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
