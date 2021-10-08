using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerUpTimeUp : MonoBehaviour
{

    public GameObject controladorReinicio;
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision jugador)
    {
        //En otros scripts utilizo un metodo distinto para buscar un componente, pero en el camino entendí el funcionamiento del siguiente condigo por lo cual tambien lo utilice, para tener ambos de referencia.
        ControladorReinicio controlador = (ControladorReinicio)controladorReinicio.GetComponent<ControladorReinicio>();
        controlador.tiempoTemporizador += 30f;
        desaparecerPowerUp();
    }
    void desaparecerPowerUp()
    {
        Destroy(gameObject);
    }
}
