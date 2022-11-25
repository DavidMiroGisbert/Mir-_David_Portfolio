using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarJuego : MonoBehaviour
{
    public GameObject personaje;
    public GameObject respawnPC1, respawnPC2, respawnPC3, respawnPC4;
    public CombatManager CombMan_Script;
    public Guardado Guardado_Script;

    GameObject Boss1;
    GameObject Boss2;
    GameObject Boss3;
    GameObject Boss4;

    public GameObject Brayan;
    public GameObject Tokola;
    public GameObject Bucket;
    public GameObject Hormiga;
    public GameObject Diego;
    public GameObject HotPaco;

    GameObject BrayanCol;
    GameObject TokolaCol;
    GameObject BucketCol;
    GameObject HormigaCol;
    GameObject DiegoCol;
    GameObject HotPacoCol;

    public GameObject BotonHuir;
    public GameObject BotonGarras;
    public GameObject BotonPlumas;

    public int TokolaDestruida0;
    public int BrayanDestruido0;

    public int BucketDestruido0;
    public int HormigaDestruida0;
    public int DiegoDestruido0;
    public int HotPacoDestruido0;

    private void Update()
    {
        //TokolaDestruida0 = Tokola.GetComponent<Dialogo_Manager>().TokolaDestruida;

    }
    void Start()
    {
        if (PlayerPrefs.GetInt("continuar") == 1)
        {
            setup_inicial(PlayerPrefs.GetInt("puntoControl"));

            //BOSSES
            if (PlayerPrefs.GetInt("contadorBoss") >= 2)
            {
                Boss1 = GameObject.FindGameObjectWithTag("BossAlcantarilla");
                Destroy(Boss1);
            }

            if (PlayerPrefs.GetInt("contadorBoss") >= 3)
            {
                Boss2 = GameObject.FindGameObjectWithTag("BossPlaya");
                Destroy(Boss2);
            }

            if (PlayerPrefs.GetInt("contadorBoss") >= 4)
            {
                Boss3 = GameObject.FindGameObjectWithTag("BossCiudad");
                Destroy(Boss3);
            }

            if (PlayerPrefs.GetInt("contadorBoss") >= 5)
            {
                Boss4 = GameObject.FindGameObjectWithTag("BossParque");
                Destroy(Boss4);
            }
            
            if (PlayerPrefs.GetInt("Hab1Desb") == 1)
            {
                BotonHuir.SetActive(true);
            }

            if (PlayerPrefs.GetInt("Hab2Desb") == 1)
            {
                BotonGarras.SetActive(true);
            }

            if (PlayerPrefs.GetInt("Hab3Desb") == 1)
            {
                BotonPlumas.SetActive(true);
            }


            //NPCS
            if(PlayerPrefs.GetInt("BrayanDestruido") > 0)
            {
                Brayan = GameObject.FindGameObjectWithTag("Brayan");
                Brayan.SetActive(false);
                BrayanCol = GameObject.FindGameObjectWithTag("BrayanCol");
                Destroy(BrayanCol);
            }

            if (PlayerPrefs.GetInt("TokolaDestruida") > 0)
            {
                Tokola = GameObject.FindGameObjectWithTag("Tokola");
                Tokola.SetActive(false);
                TokolaCol = GameObject.FindGameObjectWithTag("TokolaCol");
                Destroy(TokolaCol);
            }


            //COMPAÑEROS
            if (PlayerPrefs.GetInt("BucketDestruido") > 0)
            {
                CombMan_Script.GetComponent<CombatManager>().contadorCompanyeros++;
                Bucket.SetActive(false);
                Bucket.GetComponent<Dialogo_Manager>().bucketpass = true;
                BucketCol = GameObject.FindGameObjectWithTag("BucketCol");
                Destroy(BucketCol);
            }

            if (PlayerPrefs.GetInt("HormigaDestruida") > 0)
            {
                CombMan_Script.GetComponent<CombatManager>().contadorCompanyeros++;
                Hormiga.SetActive(false);
                Hormiga.GetComponent<Dialogo_Manager>().hormipass = true;
                HormigaCol = GameObject.FindGameObjectWithTag("HormigaCol");
                Destroy(HormigaCol);
            }

            if (PlayerPrefs.GetInt("DiegoDestruido") > 0)
            {
                CombMan_Script.GetComponent<CombatManager>().contadorCompanyeros++;
                Diego = GameObject.FindGameObjectWithTag("Diego");
                Diego.SetActive(false);
                Diego.GetComponent<Dialogo_Manager>().diegopass = true;
                DiegoCol = GameObject.FindGameObjectWithTag("DiegoCol");
                Destroy(DiegoCol);
            }

            if (PlayerPrefs.GetInt("HotPacoDestruido") > 0)
            {
                CombMan_Script.GetComponent<CombatManager>().contadorCompanyeros++;
                HotPaco = GameObject.FindGameObjectWithTag("HotPaco");
                HotPaco.SetActive(false);
                HotPaco.GetComponent<Dialogo_Manager>().hotpacopass = true;
                HotPacoCol = GameObject.FindGameObjectWithTag("HotPacoCol");
                Destroy(HotPacoCol);
            }

            if (PlayerPrefs.GetInt("acceso1int") > 0)
            {
                personaje.GetComponent<Metro>().aceso1 = true;
            }

            if (PlayerPrefs.GetInt("acceso2int") > 0)
            {
                personaje.GetComponent<Metro>().aceso2 = true;
            }

            if (PlayerPrefs.GetInt("acceso3int") > 0)
            {
                personaje.GetComponent<Metro>().aceso3 = true;
            }

            if (PlayerPrefs.GetInt("acceso4int") > 0)
            {
                personaje.GetComponent<Metro>().aceso4 = true;
            }
        }
    }

    void setup_inicial(int puntoControl)
    {
        //Vida al 100%
        personaje.GetComponent<Objetos>().objetos_lista[0] = PlayerPrefs.GetInt("maspp");
        personaje.GetComponent<Objetos>().objetos_lista[1] = PlayerPrefs.GetInt("restos");
        personaje.GetComponent<Objetos>().objetos_lista[2] = PlayerPrefs.GetInt("restos++");
        personaje.GetComponent<Objetos>().objetos_lista[3] = PlayerPrefs.GetInt("ultrarestos");

        CombMan_Script.GetComponent<CombatManager>().contadorBoss = PlayerPrefs.GetInt("contadorBoss");

        CombMan_Script.GetComponent<CombatManager>().Hab1Desb = PlayerPrefs.GetInt("Hab1Desb");
        CombMan_Script.GetComponent<CombatManager>().Hab2Desb = PlayerPrefs.GetInt("Hab2Desb");
        CombMan_Script.GetComponent<CombatManager>().Hab3Desb = PlayerPrefs.GetInt("Hab3Desb");

        Tokola.GetComponent<Dialogo_Manager>().TokolaDestruida = PlayerPrefs.GetInt("TokolaDestruida");
        Bucket.GetComponent<Dialogo_Manager>().BucketDestruido = PlayerPrefs.GetInt("BucketDestruido");
        Hormiga.GetComponent<Dialogo_Manager>().HormigaDestruida = PlayerPrefs.GetInt("HormigaDestruida");
        Diego.GetComponent<Dialogo_Manager>().DiegoDestruido = PlayerPrefs.GetInt("DiegoDestruido");
        HotPaco.GetComponent<Dialogo_Manager>().HotPacoDestruido = PlayerPrefs.GetInt("HotPacoDestruido");
        Brayan.GetComponent<Dialogo_Manager>().BrayanDestruido = PlayerPrefs.GetInt("BrayanDestruido");

        personaje.GetComponent<Metro>().acceso1int = PlayerPrefs.GetInt("acceso1int");
        personaje.GetComponent<Metro>().acceso2int = PlayerPrefs.GetInt("acceso2int");
        personaje.GetComponent<Metro>().acceso3int = PlayerPrefs.GetInt("acceso3int");
        personaje.GetComponent<Metro>().acceso4int = PlayerPrefs.GetInt("acceso4int");



        switch (puntoControl)
        {
            case 0:
                personaje.GetComponent<Objetos>().objetos_lista[0] = 2;
                personaje.GetComponent<Objetos>().objetos_lista[1] = 2;
                personaje.GetComponent<Objetos>().objetos_lista[2] = 2;
                personaje.GetComponent<Objetos>().objetos_lista[3] = 2;
                break;
            case 1:
               personaje.transform.position = respawnPC1.transform.position;
               break;
            case 2:
                personaje.transform.position = respawnPC2.transform.position;
                break;
            case 3:
                personaje.transform.position = respawnPC3.transform.position;
                break;
            case 4:
                personaje.transform.position = respawnPC4.transform.position;
                break;
        }
    }
}