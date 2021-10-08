using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PuertaEnemigos : MonoBehaviour
{
    public List<GameObject> listaEnemigos;

    public Text textoEnemigosRestantes;
    private int enemigosRestantes;
    private bool puedoSubir = true;
    void Start()
    {
        enemigosRestantes = listaEnemigos.Count;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject enemigo in listaEnemigos)
        {

            if (enemigo == null)
            {
                enemigosRestantes -= 1;
                listaEnemigos.Remove(enemigo);
            }

        

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
