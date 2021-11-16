using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataPersistencia

{
    public int puntajeMaximo = 0;

    public DataPersistencia(int puntajeAGuardar)
    {
        puntajeMaximo = puntajeAGuardar;
    }
}
