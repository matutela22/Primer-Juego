using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportamientoBala : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Piso"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.name == "Jugador")
        {
            GameObject jugador = GameObject.Find("Jugador");
            ControlJugador scriptJugador = jugador.GetComponent<ControlJugador>();
            if (scriptJugador != null)
            {
                Destroy(gameObject);
                scriptJugador.recibirDaño();
            }
        }
    }


}
