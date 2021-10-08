using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroParaEnanos : MonoBehaviour
{
    public ControlJugador scriptJugador;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            scriptJugador.GameOver();
        }
    }
}
      
