using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogo 
{
    public string locutor;

    [TextArea(3,10)]

    public string[] listafrases;
}
