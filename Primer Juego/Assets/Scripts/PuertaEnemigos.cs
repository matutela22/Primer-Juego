using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PuertaEnemigos : MonoBehaviour
{
    public Text textoEnemigosRestantes;
    private int enemigosRestantes;
    public ControlBot bot1;
    public ControlBot bot2;
    private bool bot1Muerto = false;
    private bool bot2Muerto = false;
    private bool puedoSubir = true;
    void Start()
    {
        enemigosRestantes = 2;

    }

    // Update is called once per frame
    void Update()
    {
        if (bot1.hp <= 0 && !bot1Muerto)
        {
            enemigosRestantes -= 1;
            bot1Muerto = true;
        }

        if (bot2.hp <= 0 && !bot2Muerto)
        {
            enemigosRestantes -= 1;
            bot2Muerto = true; 
        }

        textoEnemigosRestantes.text = "Enemigos Restantes: " + enemigosRestantes;
    
        if (enemigosRestantes <= 0)
        {
            abrirPuerta();
        }
    
    }

    void abrirPuerta()
    {
        if (puedoSubir)
        {
            transform.position += new Vector3(0f, 5f, 0f) * Time.deltaTime;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rebote"))
        {
            puedoSubir = false;
        }
    }

}
