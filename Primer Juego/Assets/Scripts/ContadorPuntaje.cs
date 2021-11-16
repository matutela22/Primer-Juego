using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorPuntaje : MonoBehaviour
{
    public int puntajeActual;
    public Text textoCantidad;

    void Start()
    {
        puntajeActual = 0;
    }

    void Update()
    {
        textoCantidad.text = "Puntaje Actual: " + puntajeActual;
    }
}
