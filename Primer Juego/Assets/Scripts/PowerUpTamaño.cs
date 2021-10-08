using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerUpTamaño : MonoBehaviour
{
    public GameObject jugador;
    public ControlJugador scriptJugador;
    private float tiempoRestante = 0;
    public bool enUso = false;

    private float velSaltoOriginal;
    private Vector3 tamañoOriginal;
    public Text textoTiempoRestante;

    private void Start()
    {
        tamañoOriginal = jugador.transform.localScale;
        velSaltoOriginal = scriptJugador.velSalto;
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);

        if (enUso)
        {
            if (tiempoRestante > 0)
            {
                textoTiempoRestante.text = ": " + tiempoRestante.ToString("#");
                tiempoRestante -= Time.deltaTime;
            }

            else
            {
                jugador.transform.localScale = tamañoOriginal;
                scriptJugador.velSalto = velSaltoOriginal;
                enUso = false;
                aparecerPowerUp();
            }
        }
    }

    private void OnCollisionEnter(Collision jugador)
    {
        enUso = true;
        tiempoRestante = 5;
        desaparecerPowerUp();

        if (gameObject.name == "PowerUpTamaño+")
        {
            jugador.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            scriptJugador.velSalto *= 2f;
        }
        else
        {
            jugador.transform.localScale += new Vector3(-0.5f, -0.5f, -0.5f);
        }

    }

    private void desaparecerPowerUp()
    {
        textoTiempoRestante.gameObject.SetActive(true);
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }

    private void aparecerPowerUp()
    {
        textoTiempoRestante.gameObject.SetActive(false);
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
}
