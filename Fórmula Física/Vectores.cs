using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vectores 
{
    //Constructor para tener ciertas acciones de vectores preestablecidas
    #region variables

    public float x;
    public float y;
    public float z;

    #endregion Variables 

    #region Constructores

    public Vectores()
    {
        x = 0;
        y = 0;
        z = 0;
    }

    public Vectores(float _x, float _y, float _z)
    {
        x = _x;
        y = _y;
        z = _z;
    }

    public Vectores(float Ax, float Ay, float Az, float vescalar)
    {
        float angulo = Mathf.Pow(Mathf.Cos(Ax), 2f) + Mathf.Pow(Mathf.Cos(Ay), 2f) + Mathf.Pow(Mathf.Cos(Az), 2f);
       
        if (angulo == 1)
        {
            x = vescalar * Mathf.Cos(Ax);
            y = vescalar * Mathf.Cos(Ay);
            z = vescalar * Mathf.Cos(Az);
            Debug.Log("Los angulos directores son "+ x + "," + y + "," + z);
        }

        else 
        {
            Debug.Log("La suma de los cuadrados de los cosenos directores siempre debe de ser igual a 1");
        }    
    }
    #endregion Constructores

    #region Metodos
    public float Magnitude(float pasame_x, float pasame_y, float pasame_z)
    {
        float vescalar;
        
        vescalar = Mathf.Sqrt(pasame_x * pasame_x + pasame_y* pasame_y + pasame_z* pasame_z);
       
        Debug.Log("El modulo del vector = " + vescalar);
        
        return vescalar;
    }

    public Vectores Normalize(float pasame_x, float pasame_y, float pasame_z)
    {
        Vectores h = new Vectores();
        
        h.x = pasame_x / Magnitude(x, y, z);
        h.y = pasame_y / Magnitude(x, y, z);
        h.z = pasame_z / Magnitude(x, y, z);

        Debug.Log("Vector normalizado = " + x + "," + y + "," + z);
        Magnitude(x, y, z);
        return h;
    }

    public static Vectores Reverse(float num1, float num2, float num3)
    {
        Vectores r = new Vectores();
        r.x = -num1;
        r.y = -num2;
        r.z = -num3;

        Debug.Log("Vector reserso = " + r.x + "," + r.y + "," + r.z);
        return r;
    }
  
    public static Vectores Suma(Vectores uno, Vectores dos)
    {
        Vectores r = new Vectores();

        r.x = uno.x + dos.x;
        r.y = uno.y + dos.y;
        r.z = uno.z + dos.z;

        Debug.Log("a) vector suma = " + r.x + "," + r.y + "," + r.z);
        return r;
    }

    public static Vectores Resta(Vectores uno, Vectores dos)
    {
        Vectores r = new Vectores();

        r.x = uno.x - dos.x;
        r.y = uno.y - dos.y;
        r.z = uno.z - dos.z;
        Debug.Log("b) vector Resta = " + r.x + "," + r.y + "," + r.z);
        return r;
    }

    public static Vectores Multiplicacion(Vectores uno, Vectores dos)
    {
        Vectores r = new Vectores();

        r.x = uno.x * dos.x;
        r.y = uno.y * dos.y;
        r.z = uno.z * dos.z;
        Debug.Log("vector Multiplicacion = " + r.x + "," + r.y + "," + r.z);
        return r;
    }

    public static Vectores Division(Vectores uno, Vectores dos)
    {
        Vectores r = new Vectores();

        r.x = uno.x / dos.x;
        r.y = uno.y / dos.y;
        r.z = uno.z / dos.z;
        Debug.Log("vector division = " + r.x + "," + r.y + "," + r.z);
        return r;
    }

    public static float Productoescalar(Vectores uno, Vectores dos)
    {
        float p;
        p = (uno.x * dos.x) + (uno.y * dos.y) + (uno.z * dos.z);

        Debug.Log("e) El producto escalar = " + p);

        return p;
    }

    public static Vectores Productovectorial(Vectores uno, Vectores dos)
    {
        
        Vectores r = new Vectores();
        Vectores n = new Vectores(0, 0, 0);

        r.x = (uno.y * dos.z) - (uno.z * dos.y);
        r.y = (uno.x * dos.z) - (uno.z * dos.x);
        r.z = (uno.x * dos.y) - (uno.y * dos.x);

        if (r == n)
        {
            Debug.Log("f) Los vectores son paralelos");
        }
        else
        {
            Debug.Log("f) El producto vectorial = " + r.x + "," + r.y + "," + r.z);
        }
        return r;
    }

    public Vector3 tovector3() 

    { return new Vector3(x,y,z); }

    #endregion Metodos
    
    #region operators

    public static Vectores operator +(Vectores uno, Vectores dos)
    {
        Vectores r = new Vectores();

        r.x = uno.x + dos.x;
        r.y = uno.y + dos.y;
        r.z = uno.z + dos.z;

        Debug.Log("a) vector suma con operator = " + r.x + "," + r.y + "," + r.z);
        return r;
    }

    public static Vectores operator -(Vectores uno, Vectores dos)
    {
        Vectores r = new Vectores();

        r.x = uno.x - dos.x;
        r.y = uno.y - dos.y;
        r.z = uno.z - dos.z;
        Debug.Log("b) vector Resta con operator = " + r.x + "," + r.y + "," + r.z);
        return r;
    }

    public static Vectores operator *(Vectores uno, Vectores dos)
    {
        Vectores r = new Vectores();
        Vectores n = new Vectores(0, 0, 0);

        r.x = (uno.y * dos.z) - (uno.z * dos.y);
        r.y = (uno.x * dos.z) - (uno.z * dos.x);
        r.z = (uno.x * dos.y) - (uno.y * dos.x);

        if (r == n)
        {
            Debug.Log("g) Los vectores son paralelos");
        }
        else
        {
            Debug.Log("g) El producto vectorial con operators = " + r.x + "," + r.y + "," + r.z);
        }
        return r;
    }

    public static Vectores operator *(Vectores uno, float numero)
    {
        Vectores r = new Vectores();

        r.x = uno.x * numero;
        r.y = uno.y * numero;
        r.z = uno.z * numero;
        Debug.Log("c) vector Multiplicacion con operator = " + r.x + "," + r.y + "," + r.z);
        return r;
    }

    public static Vectores operator /(Vectores uno, Vectores dos)
    {
        Vectores r = new Vectores();

        r.x = uno.x / dos.x;
        r.y = uno.y / dos.y;
        r.z = uno.z / dos.z;
        Debug.Log("vector division con operator = " + r.x + "," + r.y + "," + r.z);
        return r;
    }

    public static Vectores operator /(Vectores uno, float numero)
    {
        Vectores r = new Vectores();

        r.x = uno.x / numero;
        r.y = uno.y / numero;
        r.z = uno.z / numero;
        Debug.Log("d) vector division con operator de = " + r.x + "," + r.y + "," + r.z);
        return r;
    }

    #endregion operators


   
}
