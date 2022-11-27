using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static float time;
    public Text TiempoUI;
    

    void Update() //Da comienzo al tiempo una vez iniciado el juego
    {
        time += Time.deltaTime;
        TiempoUI.text = time.ToString("f0");
    }
   
}
