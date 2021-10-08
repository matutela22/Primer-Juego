using UnityEngine;
using UnityEngine.UI;
public class PowerUpvelocidad : MonoBehaviour
{
    public ControlJugador scriptJugador;
    private float tiempoRestante = 0;
    public bool enUso = false;

    public Text textoTiempoRestante;

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
                scriptJugador.rapidezDesplazamiento = 10;
                enUso = false;
                aparecerPowerUp();
            }
        }
    }

    private void OnCollisionEnter(Collision jugador)
    {
        enUso = true;
        scriptJugador.rapidezDesplazamiento = 25;
        tiempoRestante = 5;
        desaparecerPowerUp();
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
