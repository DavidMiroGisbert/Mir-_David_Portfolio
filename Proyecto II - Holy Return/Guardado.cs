using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardado : MonoBehaviour
{
    public GameObject personaje;
    public GameObject CombatMan_Script;

    public GameObject Brayan0;
    public GameObject Tokola0;
    public GameObject Bucket0;
    public GameObject Hormiga0;
    public GameObject Diego0;
    public GameObject HotPaco0;



    //sitio de guardado (4) ; maspp; pocion; superpocion; supermaspp; 

    void OnTriggerEnter2D(Collider2D other)
    {
        //print("Dentro del trigger de guardado" + other.transform.name);
        // Efecto visual + sonido + mensaje
        switch (other.transform.name)
        {
            case "Punto1":
                PlayerPrefs.SetInt("puntoControl", 1);
                GuardarObjetos();
                GuardarBosses();
                GuardarHabilidades();
                GuardarCompañeros();
                Brayan();
                Tokola();
                Metro();
                break;

            case "Punto2":
                PlayerPrefs.SetInt("puntoControl", 2);
                GuardarObjetos();
                GuardarBosses();
                GuardarHabilidades();
                GuardarCompañeros();
                Brayan();
                Tokola();
                Metro();
                break;

            case "Punto3":
                PlayerPrefs.SetInt("puntoControl", 3);
                GuardarObjetos();
                GuardarBosses();
                GuardarHabilidades();
                GuardarCompañeros();
                Brayan();
                Tokola();
                Metro();
                break;

            case "Punto4":
                PlayerPrefs.SetInt("puntoControl", 4);
                GuardarObjetos();
                GuardarBosses();
                GuardarHabilidades();
                GuardarCompañeros();
                Brayan();
                Tokola();
                Metro();
                break;
        }
    }

    void GuardarObjetos()
    {
        PlayerPrefs.SetInt("maspp", personaje.GetComponent<Objetos>().objetos_lista[0]);
        PlayerPrefs.SetInt("restos", personaje.GetComponent<Objetos>().objetos_lista[1]);
        PlayerPrefs.SetInt("restos++", personaje.GetComponent<Objetos>().objetos_lista[2]);
        PlayerPrefs.SetInt("ultrarestos", personaje.GetComponent<Objetos>().objetos_lista[3]);
    }

    void GuardarBosses()
    {
        PlayerPrefs.SetInt("contadorBoss", CombatMan_Script.GetComponent<CombatManager>().contadorBoss);
    }

    void GuardarHabilidades()
    {
        PlayerPrefs.SetInt("Hab1Desb", CombatMan_Script.GetComponent<CombatManager>().Hab1Desb);
        PlayerPrefs.SetInt("Hab2Desb", CombatMan_Script.GetComponent<CombatManager>().Hab2Desb);
        PlayerPrefs.SetInt("Hab3Desb", CombatMan_Script.GetComponent<CombatManager>().Hab3Desb);
    }

    void GuardarCompañeros()
    {
        PlayerPrefs.SetInt("BucketDestruido", Bucket0.GetComponent<Dialogo_Manager>().BucketDestruido);
        PlayerPrefs.SetInt("HormigaDestruida", Hormiga0.GetComponent<Dialogo_Manager>().HormigaDestruida);
        PlayerPrefs.SetInt("DiegoDestruido", Diego0.GetComponent<Dialogo_Manager>().DiegoDestruido);
        PlayerPrefs.SetInt("HotPacoDestruido", HotPaco0.GetComponent<Dialogo_Manager>().HotPacoDestruido);
    }

    void Brayan()
    {
        PlayerPrefs.SetInt("BrayanDestruido", Brayan0.GetComponent<Dialogo_Manager>().BrayanDestruido);
    }

    void Tokola()
    {
        PlayerPrefs.SetInt("TokolaDestruida", Tokola0.GetComponent<Dialogo_Manager>().TokolaDestruida);
    }

    void Metro()
    {
        PlayerPrefs.SetInt("acceso1int", personaje.GetComponent<Metro>().acceso1int);
        PlayerPrefs.SetInt("acceso2int", personaje.GetComponent<Metro>().acceso2int);
        PlayerPrefs.SetInt("acceso3int", personaje.GetComponent<Metro>().acceso3int);
        PlayerPrefs.SetInt("acceso4int", personaje.GetComponent<Metro>().acceso4int);
    }
}