using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    //Generación del terreno mediante ruido(Perlin noise)
    public int depth = 20;
    public bool facil = false;
    public bool normal = false;
    public bool dificil = false;

    public GameObject pared;
    public GameObject pared2;
    public GameObject pared3;
    public GameObject cañon;
    public GameObject PowerUp;

    public int width = 256;
    public int height = 256;

    public float scale = 20f;

    public float offsetX = 200f;
    public float offsetY = 200f;

    public float velocity = 5f;

    float TimeAux;

    private void Start()
    {
        StartCoroutine("Wait2");
        offsetX = Random.Range(0f, 99999f);
        offsetY = Random.Range(0f, 99999f);
        TimeAux = Time.time;
        GenerateHeights();
       
    }
    
    // Start is called before the first frame update
    void Update()
    {
        float timeDif = Time.time - TimeAux;
        offsetX += velocity * Time.deltaTime;
        
    }

    private IEnumerator Wait2()
    {
        yield return new WaitForSeconds(3f);
        GenerateHeights();
        StartCoroutine("Wait2");
    }
        float[,] GenerateHeights() //Ruido
    {
       
        float[,] heights = new float[width, height];
        
            for (int z = 0; z < height; z++)
          {
                int x = 0;
                int selectorpared = Random.Range(0, 101);
                float valor = CalculateHeight(x, z);
                Vector3 posicion = new Vector3(x, 0f, z);
                Vector3 posicionPUp = new Vector3(x, 0.25f, z);
                Vector3 posicionT = new Vector3(x, 10f, z);
            Debug.Log(valor);

            //FACIL

            if (facil==true)
            {
                if (valor > 0.4f)
                {
                    if (selectorpared<34)
                    {
                        GameObject clon = Instantiate(pared, posicion, Quaternion.identity) as GameObject;
                        clon.SetActive(true);
                    }
                    if (selectorpared>=34 && selectorpared<66)
                    {
                        GameObject clon = Instantiate(pared2, posicion, Quaternion.identity) as GameObject;
                        clon.SetActive(true);
                    }
                    if (selectorpared>=66)
                    {
                        GameObject clon = Instantiate(pared3, posicion, Quaternion.identity) as GameObject;
                        clon.SetActive(true);
                    }
                    
                }
                else
                {

                    int spawner = Random.Range(1, 101);
                    if (spawner < 5)
                    {
                        GameObject clon = Instantiate(cañon, posicionT, Quaternion.identity) as GameObject;
                        clon.SetActive(true);
                    }
                    if (spawner > 85)
                    {
                        GameObject clon = Instantiate(PowerUp, posicionPUp, Quaternion.identity) as GameObject;
                        clon.SetActive(true);
                    }

                }
            }

            //NORMAL

            if (normal==true)
            {
                if (valor > 0.4f)
                {
                    if (selectorpared < 34)
                    {
                        GameObject clon = Instantiate(pared, posicion, Quaternion.identity) as GameObject;
                        clon.SetActive(true);
                    }
                    if (selectorpared >= 34 && selectorpared < 66)
                    {
                        GameObject clon = Instantiate(pared2, posicion, Quaternion.identity) as GameObject;
                        clon.SetActive(true);
                    }
                    if (selectorpared >= 66)
                    {
                        GameObject clon = Instantiate(pared3, posicion, Quaternion.identity) as GameObject;
                        clon.SetActive(true);
                    }
                }
                else
                {

                    int spawner = Random.Range(1, 101);
                    if (spawner < 15)
                    {
                        GameObject clon = Instantiate(cañon, posicionT, Quaternion.identity) as GameObject;
                        clon.SetActive(true);
                    }
                    if (spawner > 90)
                    {
                        GameObject clon = Instantiate(PowerUp, posicionPUp, Quaternion.identity) as GameObject;
                        clon.SetActive(true);
                    }

                }
            }

            //DIFÍCIL

            if (dificil==true)
            {
                if (valor > 0.4f)
                {
                    if (selectorpared < 34)
                    {
                        GameObject clon = Instantiate(pared, posicion, Quaternion.identity) as GameObject;
                        clon.SetActive(true);
                    }
                    if (selectorpared >= 34 && selectorpared < 66)
                    {
                        GameObject clon = Instantiate(pared2, posicion, Quaternion.identity) as GameObject;
                        clon.SetActive(true);
                    }
                    if (selectorpared >= 66)
                    {
                        GameObject clon = Instantiate(pared3, posicion, Quaternion.identity) as GameObject;
                        clon.SetActive(true);
                    }
                }
                else
                {

                    int spawner = Random.Range(1, 101);
                    if (spawner < 25)
                    {
                        GameObject clon = Instantiate(cañon, posicionT, Quaternion.identity) as GameObject;
                        clon.SetActive(true);
                    }
                    if (spawner > 97)
                    {
                        GameObject clon = Instantiate(PowerUp, posicionPUp, Quaternion.identity) as GameObject;
                        clon.SetActive(true);
                    }

                }
            }
          }
        

        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
