using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int numeroOleada;
    public int cantidadEnemigosSpawneados;
    public int enemigosMuertos;

    public GameObject enemigo;
    public GameObject[] spawners;
    private int numeroNombreEnemigo = 0;
    void Start()
    {
        Oleadainicial();

        spawners = new GameObject[4];

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnearEnemigo();
        }
    }

    private void SpawnearEnemigo()
    {
        int spawnRandom = Random.Range(0, spawners.Length);
        Instantiate(enemigo, spawners[spawnRandom].transform.position, spawners[spawnRandom].transform.rotation);
        enemigo.name = "Enemigo" + numeroNombreEnemigo;
        numeroNombreEnemigo++;
    }

    private void Oleadainicial()
    {
        numeroOleada = 1;
        cantidadEnemigosSpawneados = 2;
        enemigosMuertos = 0;

        for (int i = 0; i < cantidadEnemigosSpawneados; i++)
        {
            SpawnearEnemigo();
        }
    }

    public void ProximaOleada()
    {
        numeroOleada += 1;
        cantidadEnemigosSpawneados += 2;
        enemigosMuertos = 0;

        for (int i = 0; i < cantidadEnemigosSpawneados; i++)
        {
            SpawnearEnemigo();
        }
    }
}
