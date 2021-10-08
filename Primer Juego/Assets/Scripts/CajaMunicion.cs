using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMunicion : MonoBehaviour
{
    public ControlJugador scriptJugador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision jugador)
    {
        desaparecerPowerUp();
        scriptJugador.municionTotal += 30;
    }

    private void desaparecerPowerUp()
    {
        Destroy(gameObject);
    }
        
}
