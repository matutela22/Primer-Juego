using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueAchicarrador : MonoBehaviour
{

    public float velocidadMovimiento;
    private bool deboCaer = true;
    public ControlJugador scriptJugador;

    void Update()
    {
        if (deboCaer)
        {
            transform.position = transform.position + new Vector3(0f, -velocidadMovimiento*4, 0f) * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position + new Vector3(0f, velocidadMovimiento*1.5f, 0f) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rebote"))
        {
            deboCaer = true;
        }

        if (other.CompareTag("Piso"))
        {
            deboCaer = false;
        }

        if (other.CompareTag("Jugador"))
        {
            scriptJugador.GameOver();
        }
    }
}
