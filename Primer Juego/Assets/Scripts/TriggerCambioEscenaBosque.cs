using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCambioEscenaBosque : MonoBehaviour
{
    private GameObject tpDestino;
    void Start()
    {
        tpDestino = GameObject.Find("TPDestino");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Alo");
        if (other.gameObject.name == "Jugador")
        {
            other.transform.position = tpDestino.transform.position;
        }
    }
}
