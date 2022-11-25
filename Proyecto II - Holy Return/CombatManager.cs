using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{
    //Gestión del tiempo
    public float tiempoInicial, tiempoAnimacion;

    //prefabs del enemigo 
    GameObject Enemy;
    public GameObject EnemyType1; 
    public GameObject EnemyType2;
    public GameObject EnemyType3;
    public GameObject EnemyType4;
    public GameObject EnemyType5;
    public GameObject EnemyType6;
    public GameObject EnemyType7;
    public GameObject EnemyType8;
    public GameObject EnemyType9;

    public GameObject CanvasCombate; //Canvas que solo estará activo durante el combate
    public GameObject TextoVictoriaCombEnemigos;
    public GameObject TextoVictoriaCombBosses;
    public GameObject TextoHabDesbloqueada;
    public Text habDesbText;

    bool plumasEnCombate; //Booleana para comprobar si se ha usado la habilidad de plumas de dios
    bool turnoJugador; //Booleana para comprobar si es el turno del jugador
    public static int TipoEnemigos; //Entero que variara según la zona en la que se este y permitirá que se instancien enemigos cada vez más fuertes
    int NumEnemigos; //Entero para decretar cuántos enemigos habrá en pantalla

    public float vidaEnemigosCambiable;

    public List<Enemigo> ListaStatsEnemigos = new List<Enemigo>();//Lista donde se crean los enemigos y sus stats
    public List<GameObject> EnemigosEnCombate = new List<GameObject>();//Lista donde se almacenan los sprites de los enemigos
    public List<GameObject> EnemigosEnEscena = new List<GameObject>();

    public Image BarraDeVidaEnemigo;
    public Image BarraDeVidaBoss;

    public GameObject BarraRojaEnemigos;
    public GameObject BarraNegraEnemigos;
    public GameObject BarraRojaBosses;
    public GameObject BarraNegraBosses;



    //BOOLS COMPAÑEROS
    public int contadorCompanyeros;


    //public List<bool> CompBool;
    public Dialogo_Manager dmbucket;
    public Dialogo_Manager dmhormibuff;
    public Dialogo_Manager dmdiego;
    public Dialogo_Manager dmhotpaco;

    //COMPAÑEROS
    public GameObject bucket;
    public GameObject Hormibuff;
    public GameObject Diego;
    public GameObject HotPaco;
    

    int PosY = -105;
    int PosX = 200;

    public GameObject Player; 

    public List<Button> botonesAccion = new List<Button>(); //Lista que almacena el número de botones que hay en el canvas

    public bool jugadorMuerto; //Booleana que comprueba si el jugador sigue con vida
    public bool enemigoMuerto; //Booleana que comprueba si los enemigos siguen con vida

    Animator anim; //Variable animator para cambiar las animaciones


    //ENEMIGOS EN LA ESCENA DE PRUEBA
    public GameObject EnemigoEnLaEscenaDePrueba1;
    public GameObject EnemigoEnLaEscenaDePrueba2;
    public GameObject EnemigoEnLaEscenaDePrueba3;


    //BOSSES
    public int contadorBoss;
    public Bosses BossActual;
    public GameObject BossEnEscena;
    public bool BossMuerto;
    public bool CombateBoss;
    public GameObject BotonHuida;
    GameObject BossEnEscena1;

    //CANTIDAD DE ATAQUES
    public int NumeroDeAtaquesNormales;
    public int NumeroDeAtaquesConGarra;
    public int NumeroDePlumasDeDios;
    public int NumeroDeLluviaAcida;


    //TEXTOS DE CANTIDAD DE LOS MOVIMIENTOS
    public Text AtaqueNormal_text;
    public Text AtaqueConGarra_text;
    public Text AtaquePlumasDeDios_text;
    public Text AtaqueLluviaAcida_text;

    //BOOL VICTORIA SOUND 
    public bool wintheme = false;

    //Garra SFX
    public GameObject garrasfx;

    //AUDIO
    AudioSource myAudio;
    public AudioClip Ataquenormal;
    public AudioClip Ataqueg;
    public AudioClip Ataquep;
    public AudioClip Ataquea;
    public AudioClip Ataquenmy;
    public AudioClip Audboss;
    public AudioClip habilidadnew;

    public Objetos Objetos_Script;

    public int Hab1Desb;
    public int Hab2Desb;
    public int Hab3Desb;


    void Awake()
    {
        CanvasCombate.SetActive(false);
        turnoJugador = true;
        jugadorMuerto = false;
        enemigoMuerto = true;
        BossMuerto = true;
        anim = Player.GetComponent<Animator>();
        TipoEnemigos = 4;
        contadorBoss = 1;
        plumasEnCombate = false;
        CombateBoss = false;

        botonesAccion[2].gameObject.SetActive(false);
        botonesAccion[3].gameObject.SetActive(false);
        botonesAccion[4].gameObject.SetActive(false);
        botonesAccion[5].gameObject.SetActive(false);

        AtaqueNormal_text.text = "ATAQUE ("+ NumeroDeAtaquesNormales + "/25)";
        AtaqueConGarra_text.text = "ATAQUE GARRA (" + NumeroDeAtaquesConGarra + "/15)";
        AtaquePlumasDeDios_text.text = "PLUMAS DE DIOS (" + NumeroDePlumasDeDios + "/10)";
        AtaqueLluviaAcida_text.text = "LLUVIA ACIDA (" + NumeroDeLluviaAcida + "/5)";

        myAudio = GetComponent<AudioSource>();

        TextoVictoriaCombEnemigos.SetActive(false);
        TextoVictoriaCombBosses.SetActive(false);
        TextoHabDesbloqueada.SetActive(false);

        BarraRojaEnemigos.SetActive(false);
        BarraNegraEnemigos.SetActive(false);
        BarraRojaBosses.SetActive(false);
        BarraNegraBosses.SetActive(false);


        Hab1Desb = 0;
        Hab2Desb = 0;
        Hab3Desb = 0;

        vidaEnemigosCambiable = 60;

    }


    void Update()
    {
        Debug.Log(contadorCompanyeros);
        if (CharacterController.ModoCombate == true)
        {
            if (enemigoMuerto == false && BossMuerto == true)
            {
                BarraRojaBosses.SetActive(false);
                BarraNegraBosses.SetActive(false);
                BarraRojaEnemigos.SetActive(true);
                BarraNegraEnemigos.SetActive(true);
                BarraDeVidaEnemigo.fillAmount = ListaStatsEnemigos[0].vidaR / ListaStatsEnemigos[0].vidaI;
            }

            else if (enemigoMuerto == true && BossMuerto == false)
            {
                BarraRojaEnemigos.SetActive(false);
                BarraNegraEnemigos.SetActive(false);
                BarraRojaBosses.SetActive(true);
                BarraNegraBosses.SetActive(true);
                BarraDeVidaBoss.fillAmount = BossActual.vidaR / BossActual.vidaI;
            }

        }



        if (CharacterController.ModoCombate == true)
        {
            CanvasCombate.SetActive(true);
        }

        if (turnoJugador == false && EnemigosEnCombate.Count > 0)
        {
            TurnoIA();
        }

        if (turnoJugador == false && CombateBoss == true)
        {
            TurnoIA();
        }

        LevelUpPlayer();


        if (NumeroDeAtaquesNormales <= 0)
        {
            botonesAccion[0].interactable = false;
        }

        if (NumeroDeAtaquesConGarra <= 0)
        {
            botonesAccion[3].interactable = false;
        }

        if (NumeroDePlumasDeDios <= 0)
        {
            botonesAccion[4].interactable = false;
        }

        if (NumeroDeLluviaAcida <= 0)
        {
            botonesAccion[5].interactable = false;
        }


        AtaqueNormal_text.text = "ATAQUE (" + NumeroDeAtaquesNormales + "/25)";

        AtaqueConGarra_text.text = "ATAQUE GARRA (" + NumeroDeAtaquesConGarra + "/15)";

        AtaquePlumasDeDios_text.text = "PLUMAS DE DIOS (" + NumeroDePlumasDeDios + "/10)";

        AtaqueLluviaAcida_text.text = "LLUVIA ACIDA (" + NumeroDeLluviaAcida + "/5)";
    }


    #region AparicionEnemigos
    public void GenerarEnemigos() //Método para crear los sprites de los Enemigos y decretar su posición
    {
        NumEnemigos = Random.Range(1, 6);
        for (int i = 0; i <= NumEnemigos; i++)
        {
            int x = Random.Range(1, TipoEnemigos);
            SpawnEnemigos(x);

            if (i <= 2)
            {
                PosX = PosX + 4;
            }
            else if (i == 3)
            { 
                PosY = PosY + 3;
            }
            else
            {
                PosX = PosX - 4;
            }

            enemigoMuerto = false;
            GameObject EnemigoCreado = Instantiate(Enemy, transform.position, Quaternion.identity);
            EnemigoCreado.transform.position = new Vector3(PosX, PosY, -1f);
            EnemigosEnCombate.Add(EnemigoCreado);

        }
        PosY = -105;
        PosX = 200;
    }

    public void InstanciarBoss()
    {
        BotonHuida.SetActive(false);
        SpawnBoss();
        BossMuerto = false;
        CombateBoss = true;
        BossEnEscena1 = Instantiate(BossEnEscena, transform.position, Quaternion.identity);
        BossEnEscena1.transform.position = new Vector3(208f, -104f, -1f); 
    }

    public void SpawnBoss()
    {
        if (contadorBoss == 1)
        {
            BossActual = new Bosses(150, 150, 30);
        }

        if (contadorBoss == 2)
        {
            BossActual = new Bosses(200, 200, 40);
        }

        if (contadorBoss == 3)
        {
            BossActual = new Bosses(400, 400, 50);
        }

        if (contadorBoss == 4)
        {
            BossActual = new Bosses(500, 500, 75);
        }

        if (contadorBoss == 5)
        {
            BossActual = new Bosses(800, 800, 125);
        }
    }


    void SpawnEnemigos(int tipoEnemigos) //Método para la creación de los distintos tipos de enemigos y sus stats
    {
        if (tipoEnemigos == 1)
        {
            Enemigo Enemigo1 = new Enemigo(vidaEnemigosCambiable, vidaEnemigosCambiable, 5);
            Enemy = EnemyType1;
            ListaStatsEnemigos.Add(Enemigo1);
        }

        if (tipoEnemigos == 2)
        {
            Enemigo Enemigo2 = new Enemigo(vidaEnemigosCambiable, vidaEnemigosCambiable, 5);
            Enemy = EnemyType2;
            ListaStatsEnemigos.Add(Enemigo2);
        }

        if (tipoEnemigos == 3)
        {
            Enemigo Enemigo3 = new Enemigo(vidaEnemigosCambiable, vidaEnemigosCambiable, 15);
            Enemy = EnemyType3;
            ListaStatsEnemigos.Add(Enemigo3);
        }

        if (tipoEnemigos == 4)
        {
            Enemigo Enemigo4 = new Enemigo(vidaEnemigosCambiable, vidaEnemigosCambiable, 15);
            Enemy = EnemyType4;
            ListaStatsEnemigos.Add(Enemigo4);
        }

        if (tipoEnemigos == 5)
        {
            Enemigo Enemigo5 = new Enemigo(vidaEnemigosCambiable, vidaEnemigosCambiable, 25);
            Enemy = EnemyType5;
            ListaStatsEnemigos.Add(Enemigo5);
        }

        if (tipoEnemigos == 6)
        {
            Enemigo Enemigo6 = new Enemigo(vidaEnemigosCambiable, vidaEnemigosCambiable, 25);
            Enemy = EnemyType6;
            ListaStatsEnemigos.Add(Enemigo6);
        }

        if (tipoEnemigos == 7)
        {
            Enemigo Enemigo7 = new Enemigo(vidaEnemigosCambiable, vidaEnemigosCambiable, 35);
            Enemy = EnemyType7;
            ListaStatsEnemigos.Add(Enemigo7);
        }

        if (tipoEnemigos == 8)
        {
            Enemigo Enemigo8 = new Enemigo(vidaEnemigosCambiable, vidaEnemigosCambiable, 35);
            Enemy = EnemyType8;
            ListaStatsEnemigos.Add(Enemigo8);
        }

        if (tipoEnemigos == 9)
        {
            Enemigo Enemigo9 = new Enemigo(vidaEnemigosCambiable, vidaEnemigosCambiable, 40);
            Enemy = EnemyType9;
            ListaStatsEnemigos.Add(Enemigo9);
        }

    }

    #endregion
    void LevelUpPlayer()
    {
        if (contadorBoss == 2)
        {
            Hab1Desb = 1;
            Player.GetComponent<CharacterController>().Maxhealth = 150;
            TipoEnemigos = 6;
            vidaEnemigosCambiable = 100;
        }

        if (contadorBoss == 3)
        {
            Hab2Desb = 1;
            botonesAccion[3].gameObject.SetActive(true);
            Player.GetComponent<CharacterController>().Maxhealth = 200;
            TipoEnemigos = 8;
            vidaEnemigosCambiable = 150;

        }

        if (contadorBoss == 4)
        {
            Hab3Desb = 1;
            botonesAccion[4].gameObject.SetActive(true);
            Player.GetComponent<CharacterController>().Maxhealth = 300;
            TipoEnemigos = 10;
            vidaEnemigosCambiable = 225;
        }

        if (contadorBoss >= 5)
        {
            botonesAccion[5].gameObject.SetActive(true);
            Player.GetComponent<CharacterController>().Maxhealth = 400;
            TipoEnemigos = 10;
            vidaEnemigosCambiable = 250;
        }

        //COMPAÑEROS ACTIVADOS EN COMBATE
        if (dmbucket.bucketpass == true)
        {
            bucket.SetActive(true);
        }
        if (dmhormibuff.hormipass == true)
        {
            Hormibuff.SetActive(true);
        }
        if (dmdiego.diegopass == true)
        {
            Diego.SetActive(true);
        }
        if (dmhotpaco.hotpacopass == true)
        {
            HotPaco.SetActive(true);
        }
    }
    public void AtaqueNormal() //Método para el ataque básico
    {
        if(NumeroDeAtaquesNormales > 0)
        {
            anim.Play("Ataque basico");
            bucket.GetComponent<Animator>().SetTrigger("AtaqueComps");
            Hormibuff.GetComponent<Animator>().SetTrigger("AtaqueComps");
            Diego.GetComponent<Animator>().SetTrigger("AtaqueComps");
            HotPaco.GetComponent<Animator>().SetTrigger("AtaqueComps");


            myAudio.PlayOneShot(Ataquenormal);
            NumeroDeAtaquesNormales--;


            if (enemigoMuerto == false && BossMuerto == true)
            {
                for (int i = 0; i < ListaStatsEnemigos.Count; i++)
                {
                    AtaqueCompanyeros(i);

                    //Resta vida al Enemigo comun
                    ListaStatsEnemigos[i].vidaR = ListaStatsEnemigos[i].vidaR - CharacterController.danoAtaque;
                    Debug.Log(ListaStatsEnemigos[i].vidaR); //error

                    if (ListaStatsEnemigos[i].vidaR <= 0)
                    {
                        BarraDeVidaEnemigo.fillAmount = 0 / ListaStatsEnemigos[0].vidaI;
                        enemigoMuerto = true;
                        DestruirEnemiesHuida();
                        Destroy(Player.GetComponent<CharacterController>().EnemigoCombateActual);
                    }
                }

                if (enemigoMuerto == false)
                {
                    turnoJugador = false;
                }

                else if (enemigoMuerto == true)
                {
                    Player.GetComponent<Objetos>().DropEnemigos();
                    TextoVictoriaCombEnemigos.SetActive(true);
                    Debug.Log("HAS DERROTADO A LOS ENEMIGOS");
                    VolverAlModoExploracion();
                }
            }


            else if (enemigoMuerto == true && BossMuerto == false)
            {
                AtaqueCompABosses();

                //Resta vida al boss
                BossActual.vidaR = BossActual.vidaR - CharacterController.danoAtaque;
                Debug.Log(BossActual.vidaR);
                if (BossActual.vidaR <= 0)
                {
                    BarraDeVidaBoss.fillAmount = BossActual.vidaR / BossActual.vidaI;
                    BossMuerto = true;
                    contadorBoss++;
                    LevelUpPlayer();
                    Destroy(BossEnEscena);
                    Destroy(BossEnEscena1);
                }


                if (BossMuerto == false)
                {
                    turnoJugador = false;
                }

                else if (BossMuerto == true)
                {
                    if (contadorBoss < 6)
                    {
                        TextoVictoriaCombBosses.SetActive(true);
                        TextoHabDesbloqueada.SetActive(true);
                        Debug.Log("HAS DERROTADO A LOS ENEMIGOS");
                        VolverAlModoExploracion();
                        BotonHuida.SetActive(true);
                        CombateBoss = false;
                    }

                    else if (contadorBoss == 6)
                    {
                        StartCoroutine("EmpezarFinalDelJuego");
                        BotonHuida.SetActive(true);
                        TextoVictoriaCombBosses.SetActive(true);
                        Debug.Log("HAS DERROTADO A LOS ENEMIGOS");
                        VolverAlModoExploracion();
                        CombateBoss = false;
                    }
                }
            }
        }
    }

    IEnumerator EmpezarFinalDelJuego()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("Final");
    }



    public void AtaqueConGarra() //Método para la habilidad de garra en combate
    {
        bucket.GetComponent<Animator>().SetTrigger("AtaqueComps");
        Hormibuff.GetComponent<Animator>().SetTrigger("AtaqueComps");
        Diego.GetComponent<Animator>().SetTrigger("AtaqueComps");
        HotPaco.GetComponent<Animator>().SetTrigger("AtaqueComps");

        if (NumeroDeAtaquesConGarra > 0)
        {
            anim.Play("AtaqueGarra 0");
            garrasfx.SetActive(true);
            anim.SetTrigger("AtaqueComps");

            NumeroDeAtaquesConGarra--;
            myAudio.PlayOneShot(Ataqueg);
            StartCoroutine("sfx");


            if (enemigoMuerto == false && BossMuerto == true)
            {
                for (int i = 0; i < ListaStatsEnemigos.Count; i++)
                {
                    AtaqueCompanyeros(i);

                    ListaStatsEnemigos[i].vidaR = ListaStatsEnemigos[i].vidaR - CharacterController.danoGarra;
                    Debug.Log(ListaStatsEnemigos[i].vidaR);

                    if (ListaStatsEnemigos[i].vidaR <= 0)
                    {
                        BarraDeVidaEnemigo.fillAmount = 0 / ListaStatsEnemigos[0].vidaI;
                        enemigoMuerto = true;
                        //Destroy(EnemigosEnCombate[i]);
                        DestruirEnemiesHuida();
                        Destroy(Player.GetComponent<CharacterController>().EnemigoCombateActual);
                    }
                }

                if (enemigoMuerto == false)
                {
                    turnoJugador = false;
                }

                else if (enemigoMuerto == true)
                {
                    Player.GetComponent<Objetos>().DropEnemigos();
                    TextoVictoriaCombEnemigos.SetActive(true);
                    Debug.Log("HAS DERROTADO A LOS ENEMIGOS");
                    VolverAlModoExploracion();
                }
            }

            else if (enemigoMuerto == true && BossMuerto == false)
            {
                AtaqueCompABosses();

                //Resta vida al boss
                BossActual.vidaR = BossActual.vidaR - CharacterController.danoGarra;
                Debug.Log(BossActual.vidaR);
                if (BossActual.vidaR <= 0)
                {
                    BarraDeVidaBoss.fillAmount = BossActual.vidaR / BossActual.vidaI;
                    BossMuerto = true;
                    myAudio.PlayOneShot(Audboss);
                    contadorBoss++;
                    LevelUpPlayer();
                    Destroy(BossEnEscena);
                    Destroy(BossEnEscena1);
                }

                if (BossMuerto == false)
                {
                    turnoJugador = false;
                }

                else if (BossMuerto == true)
                {
                    if (contadorBoss < 6)
                    {
                        BotonHuida.SetActive(true);
                        TextoVictoriaCombBosses.SetActive(true);
                        TextoHabDesbloqueada.SetActive(true);
                        Debug.Log("HAS DERROTADO A LOS ENEMIGOS");
                        VolverAlModoExploracion();
                        CombateBoss = false;
                    }

                    else if (contadorBoss == 6)
                    {
                        StartCoroutine("EmpezarFinalDelJuego");
                        BotonHuida.SetActive(true);
                        TextoVictoriaCombBosses.SetActive(true);
                        Debug.Log("HAS DERROTADO A LOS ENEMIGOS");
                        VolverAlModoExploracion();
                        CombateBoss = false;
                    }
                }
            }
        }
    }

    IEnumerator sfx()
    {
        yield return new WaitForSeconds(0.75f);
        garrasfx.SetActive(false);
    }

    public void PlumasDeDios() //Método para la habilidad Plumas de dios en combate
    {
        bucket.GetComponent<Animator>().SetTrigger("AtaqueComps");
        Hormibuff.GetComponent<Animator>().SetTrigger("AtaqueComps");
        Diego.GetComponent<Animator>().SetTrigger("AtaqueComps");
        HotPaco.GetComponent<Animator>().SetTrigger("AtaqueComps");
        if (NumeroDePlumasDeDios > 0)
        {

            anim.Play("PlumasCombate");
            anim.SetTrigger("AtaqueComps");

            NumeroDePlumasDeDios--;
            myAudio.PlayOneShot(Ataquep);

            plumasEnCombate = true;


            if (enemigoMuerto == false && BossMuerto == true)
            {
                for (int i = 0; i < ListaStatsEnemigos.Count; i++)
                {
                    AtaqueCompanyeros(i);

                    //Resta vida al Enemigo comun
                    Debug.Log(ListaStatsEnemigos[i].vidaR);

                    if (ListaStatsEnemigos[i].vidaR <= 0)
                    {
                        BarraDeVidaEnemigo.fillAmount = 0 / ListaStatsEnemigos[0].vidaI;
                        enemigoMuerto = true;
                        plumasEnCombate = false;
                        DestruirEnemiesHuida();
                        Destroy(Player.GetComponent<CharacterController>().EnemigoCombateActual);
                    }
                }

                if (enemigoMuerto == false)
                {
                    turnoJugador = false;
                }

                else if (enemigoMuerto == true)
                {
                    Player.GetComponent<Objetos>().DropEnemigos();
                    TextoVictoriaCombEnemigos.SetActive(true);
                    Debug.Log("HAS DERROTADO A LOS ENEMIGOS");
                    VolverAlModoExploracion();
                }
            }


            else if (enemigoMuerto == true && BossMuerto == false)
            {
                AtaqueCompABosses();

                //Resta vida al boss
                Debug.Log(BossActual.vidaR);
                if (BossActual.vidaR <= 0)
                {
                    BarraDeVidaBoss.fillAmount = BossActual.vidaR / BossActual.vidaI;
                    BossMuerto = true;
                    plumasEnCombate = false;
                    contadorBoss++;
                    LevelUpPlayer();
                    Destroy(BossEnEscena);
                    Destroy(BossEnEscena1);
                }


                if (BossMuerto == false)
                {
                    turnoJugador = false;
                }

                else if (BossMuerto == true)
                {
                    if (contadorBoss < 6)
                    {
                        TextoVictoriaCombBosses.SetActive(true);
                        TextoHabDesbloqueada.SetActive(true);
                        Debug.Log("HAS DERROTADO A LOS ENEMIGOS");
                        VolverAlModoExploracion();
                        BotonHuida.SetActive(true);
                        CombateBoss = false;
                    }

                    else if (contadorBoss == 6)
                    {
                        StartCoroutine("EmpezarFinalDelJuego");
                        BotonHuida.SetActive(true);
                        TextoVictoriaCombBosses.SetActive(true);
                        Debug.Log("HAS DERROTADO A LOS ENEMIGOS");
                        VolverAlModoExploracion();
                        CombateBoss = false;
                    }
                }
            }
        }
    }

    public void AtaqueLluviaAcida() //Método para la habilidad Lluvia Acida en combate
    {
        bucket.GetComponent<Animator>().SetTrigger("AtaqueComps");
        Hormibuff.GetComponent<Animator>().SetTrigger("AtaqueComps");
        Diego.GetComponent<Animator>().SetTrigger("AtaqueComps");
        HotPaco.GetComponent<Animator>().SetTrigger("AtaqueComps");
        if (NumeroDeLluviaAcida > 0)
        {
            anim.Play("AcidoBack");
            anim.SetTrigger("AtaqueComps");

            NumeroDeLluviaAcida--;
            myAudio.PlayOneShot(Ataquea);

            if (enemigoMuerto == false && BossMuerto == true)
            {
                for (int i = 0; i < ListaStatsEnemigos.Count; i++)
                {
                    AtaqueCompanyeros(i);

                    ListaStatsEnemigos[i].vidaR = ListaStatsEnemigos[i].vidaR - CharacterController.danoLluvia;
                    Debug.Log(ListaStatsEnemigos[i].vidaR);

                    if (ListaStatsEnemigos[i].vidaR <= 0)
                    {
                        BarraDeVidaEnemigo.fillAmount = 0 / ListaStatsEnemigos[0].vidaI;
                        enemigoMuerto = true;
                        DestruirEnemiesHuida();
                        Destroy(Player.GetComponent<CharacterController>().EnemigoCombateActual);
                    }
                }

                if (enemigoMuerto == false)
                {
                    turnoJugador = false;
                }

                else if (enemigoMuerto == true)
                {
                    Player.GetComponent<Objetos>().DropEnemigos();
                    TextoVictoriaCombEnemigos.SetActive(true);
                    Debug.Log("HAS DERROTADO A LOS ENEMIGOS");
                    VolverAlModoExploracion();
                }
            }

            else if (enemigoMuerto == true && BossMuerto == false)
            {
                AtaqueCompABosses();

                //Resta vida al boss
                BossActual.vidaR = BossActual.vidaR - CharacterController.danoLluvia;
                Debug.Log(BossActual.vidaR);
                if (BossActual.vidaR <= 0)
                {
                    BarraDeVidaBoss.fillAmount = BossActual.vidaR / BossActual.vidaI;
                    BossMuerto = true;
                    contadorBoss++;
                    LevelUpPlayer();
                    Destroy(BossEnEscena);
                    Destroy(BossEnEscena1);
                }

                if (BossMuerto == false)
                {
                    turnoJugador = false;
                }

                else if (BossMuerto == true)
                {
                    if (contadorBoss < 6)
                    {
                        BotonHuida.SetActive(true);
                        TextoVictoriaCombBosses.SetActive(true);
                        TextoHabDesbloqueada.SetActive(true);
                        Debug.Log("HAS DERROTADO A LOS ENEMIGOS");
                        VolverAlModoExploracion();
                        CombateBoss = false;
                    }

                    else if (contadorBoss == 6)
                    {
                        StartCoroutine("EmpezarFinalDelJuego");
                        BotonHuida.SetActive(true);
                        TextoVictoriaCombBosses.SetActive(true);
                        Debug.Log("HAS DERROTADO A LOS ENEMIGOS");
                        VolverAlModoExploracion();
                        CombateBoss = false;
                    }
                }
            }
        }
    }


    public void AtaqueCompanyeros(int i)
    {

        for (int c = 0; c < contadorCompanyeros; c++)
        {
            //Debug.Log(c);
            int ProbCrit = Random.Range(0, 100);
            if (ProbCrit <= 10)
            {
                ListaStatsEnemigos[i].vidaR = ListaStatsEnemigos[i].vidaR - 30;
            }

            //(ProbCrit > 10 && ProbCrit < 90)
            else
            {
                ListaStatsEnemigos[i].vidaR = ListaStatsEnemigos[i].vidaR - 20;
            }
            
            /*else
            {
                Debug.Log("Ha fallado el compañero " + c);
            }*/
        }
    }


    public void AtaqueCompABosses()
    {
        for (int c = 0; c < contadorCompanyeros; c++)
        {
            //anim.SetTrigger("AtaqueComps");
            int ProbCrit = Random.Range(0, 100);
            if (ProbCrit <= 10)
            {
                BossActual.vidaR = BossActual.vidaR - 3;
            }
            if (ProbCrit > 10 && ProbCrit < 90)
            {
                BossActual.vidaR = BossActual.vidaR - 2;
            }
            else
            {
                Debug.Log("Ha fallado el compañero " + c);
            }
        }
    }


    void TurnoIA()
    {
        StartCoroutine("AtaqueDeLaIA");
        turnoJugador = true;
    }


    IEnumerator esperar()
    {
        WaitForSeconds wait = new WaitForSeconds(0.3f);
        myAudio.volume = 0.3f;
        for (int i = 0; i < EnemigosEnCombate.Count; i++)
        {         
            myAudio.PlayOneShot(Ataquenmy); //SonidoAtaqueEnemigo
            EnemigosEnCombate[i].GetComponent<Animator>().SetTrigger("Ataque");
            //Debug.Log(EnemigosEnCombate[i].transform.name);
            Player.GetComponent<CharacterController>().health = Player.GetComponent<CharacterController>().health - ListaStatsEnemigos[i].ataque;
            //Debug.Log("¡El enemigo te ha quitado 5 de vida!");
            yield return wait;

            if (Player.GetComponent<CharacterController>().health <= 0)
            {
                Debug.Log("¡¡HAS SIDO DERROTADO POR EL ENEMIGO!!");
                jugadorMuerto = true;
                SceneManager.LoadScene("EscenaDerrota");
            }
        }
    }


    IEnumerator AtaqueDeLaIA()
    {
        //Debug.Log("Comienza el turno del enemigo");
        if (Objetos_Script.GetComponent<Objetos>().CanvasActivo == true)
        {
            Objetos_Script.GetComponent<Objetos>().CanvasObjetos.SetActive(false);
        }

        //Desactiva los botones cuando es el turno de la IA
        
        for (int a = 0; a < botonesAccion.Count; a++)
        {
            if (a==0 && NumeroDeAtaquesNormales == 0)
            {
                botonesAccion[a].interactable = false;
            }
            else if (a == 0 && NumeroDeAtaquesNormales != 0)
            {
                botonesAccion[a].interactable = !botonesAccion[a].interactable;
            }

            else if (a == 1)
            {
                botonesAccion[a].interactable = false;
            }

            if (a == 2 && NumeroDeAtaquesConGarra == 2)
            {
                botonesAccion[a].interactable = false;
            }
            else if (a == 2 && NumeroDeAtaquesConGarra != 2)
            {
                botonesAccion[a].interactable = false;
            }


            if (a == 3 && NumeroDeLluviaAcida == 3)
            {
                botonesAccion[a].interactable = false;
            }
            else if (a == 3 && NumeroDeLluviaAcida != 3)
            {
                botonesAccion[a].interactable = false;
            }


            if (a == 4 && NumeroDePlumasDeDios == 4)
            {
                botonesAccion[a].interactable = false;
            }
            else if (a == 4 && NumeroDePlumasDeDios != 4)
            {
                botonesAccion[a].interactable = false;
            }
            if (a == 5 )
            {
                botonesAccion[a].interactable = false;
            }
            else if (a == 5)
            {
                botonesAccion[a].interactable = false;
            }
        }


        if (plumasEnCombate==true)
        {
            Debug.Log("Has esquivado el ataque");
            plumasEnCombate = false;
        }
        else if (plumasEnCombate == false)
        {
            if (CombateBoss == true)
            {
                BossEnEscena1.GetComponent<Animator>().SetTrigger("Ataque");
                Player.GetComponent<CharacterController>().health = Player.GetComponent<CharacterController>().health - BossActual.ataque;
                Debug.Log("¡El Boss te ha quitado mucha vida!");
            }
            else
            {
                StartCoroutine(esperar());
                myAudio.volume = 1f;
            }
        }
       
        
        if (Player.GetComponent<CharacterController>().health <= 0)
        {
            Debug.Log("¡¡HAS SIDO DERROTADO POR EL ENEMIGO!!");
            jugadorMuerto = true;
            SceneManager.LoadScene("EscenaDerrota");
        }

        yield return new WaitForSeconds(2f);

        if (jugadorMuerto == false)
        {
            for (int a = 0; a < botonesAccion.Count; a++)
            {
                botonesAccion[a].interactable = !botonesAccion[a].interactable;
            }
        }

        if (Objetos_Script.GetComponent<Objetos>().CanvasActivo == true)
        {
            Objetos_Script.GetComponent<Objetos>().CanvasObjetos.SetActive(true);
        }
    }

    void VolverAlModoExploracion()
    {
        Objetos_Script.GetComponent<Objetos>().CanvasActivo = false;
        Objetos_Script.GetComponent<Objetos>().CanvasObjetos.SetActive(false);

        for (int a = 0; a < botonesAccion.Count; a++)
        {
            botonesAccion[a].interactable = !botonesAccion[a].interactable;
        }
        StartCoroutine("TiempoDeEsperaFinalDelCombate");
    }


    IEnumerator TiempoDeEsperaFinalDelCombate()
    {
        if (CombateBoss == true)
        {
            if (contadorBoss == 2)
            {
                habDesbText.text = "HAS DESLOQUEADO LA HABILIDAD ''HUIR'' " +
                    "AHORA PUEDES HUIR DE LOS COMBATES CONTRA ENEMIGOS COMUNES";
            }

            else if (contadorBoss == 3)
            {
                habDesbText.text = "HAS DESLOQUEADO LA HABILIDAD ''ATAQUE GARRA'' " +
                    "AHORA DISPONES DE UN ATAQUE MUCHO MAS PODEROSO";
            }

            else if (contadorBoss == 4)
            {
                habDesbText.text = "HAS DESLOQUEADO LA HABILIDAD ''PLUMAS DE DIOS'' " +
                    "AHORA PUEDES ESQUIVAR ATAQUES ENEMIGOS";
            }

            else if (contadorBoss == 5)
            {
                habDesbText.text = "HAS DESLOQUEADO LA HABILIDAD ''LLUVIA ACIDA'' " +
                    "AHORA CUENTAS CON EL ATAQUE MAS FUERTE DE TODOS";
            }

            /*else if (contadorBoss == 6)
            {
                SceneManager.LoadScene("MenuInicial");
            }*/
            myAudio.PlayOneShot(habilidadnew);
            wintheme = true;
            yield return new WaitForSeconds(7f);
            wintheme = false;
        }

        else if (CombateBoss == false)
        {
            wintheme = true;
            yield return new WaitForSeconds(5f);
            wintheme = false;
        }

        TextoVictoriaCombEnemigos.SetActive(false);
        TextoVictoriaCombBosses.SetActive(false);
        TextoHabDesbloqueada.SetActive(false);
        Player.GetComponent<CharacterController>().GiroCombate();
        Player.transform.position = Player.GetComponent<CharacterController>().PosicionActual;
        Player.GetComponent<CharacterController>().CamaraCombate.SetActive(false);
        Player.GetComponent<CharacterController>().MainCamera.SetActive(true);
        CharacterController.ModoCombate = false;
        for (int a = 0; a < botonesAccion.Count; a++)
        {
            botonesAccion[a].interactable = !botonesAccion[a].interactable;
        }
    }


    public void DestruirEnemiesHuida()
    {
        StartCoroutine("EsperarParaDestruirEnemigos");
    }

    IEnumerator EsperarParaDestruirEnemigos()
    {
        yield return new WaitForSeconds(1f);
        for (int i = EnemigosEnCombate.Count-1; i >= 0; i--)
        {
            Destroy(EnemigosEnCombate[i]);
            EnemigosEnCombate.RemoveAt(i);
        }
        
        for (int a = ListaStatsEnemigos.Count-1; a >= 0; a--)
        {
            ListaStatsEnemigos.RemoveAt(a);
        }
    }
}