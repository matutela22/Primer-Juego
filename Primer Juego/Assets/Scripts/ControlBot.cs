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
        transform.Translate(rapidez * Vector3.forward*Time.deltaTime);
    }

    public void recibirDaño ()
    {
        hp = hp - 25;
        Debug.Log("Le diste a: " + gameObject.name + ". Vida restante: " + hp);
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
