using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBot : MonoBehaviour
{
    public int hp;
    private GameObject jugador;
    public int rapidez;
 
    void Start()
    {
        hp = 100;
        jugador = GameObject.Find("Jugador");
    }

    private void Update()
    {
        
        transform.LookAt(jugador.transform);
        transform.position = Vector3.MoveTowards(transform.position, jugador.transform.position, rapidez*Time.deltaTime);
        
    }

    public void recibirDaño ()
    {
        hp = hp - 25;
        if (hp <= 0)
        {
            this.desaparecer();
        }
    }

    private void desaparecer()
    {
        Destroy(gameObject);
    }
}
