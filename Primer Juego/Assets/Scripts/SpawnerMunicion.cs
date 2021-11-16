using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerMunicion : MonoBehaviour
{
    public int tiempoSpawn;
    public GameObject municion;
    public bool puedeSpawnear;
    public bool objetoRecogido;
    private Vector3 posicionSpawn;
    void Start()
    {
        objetoRecogido = false;
        puedeSpawnear = true;
        posicionSpawn = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1.5f, gameObject.transform.position.z);
    }

    void Update()
    {
        if (puedeSpawnear)
        {
            Spawner();
        }
        if (!puedeSpawnear && objetoRecogido)
        {
            StartCoroutine (IniciarCuenta());
        }
    }


    void Spawner()
    {
        puedeSpawnear = false;
        Instantiate(municion, posicionSpawn, transform.rotation);
    }

    IEnumerator IniciarCuenta()
    {
        objetoRecogido = false;

        yield return new WaitForSeconds(tiempoSpawn);
        puedeSpawnear = true;
    }
}



