using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMunicion : MonoBehaviour
{
    private ScriptPistola scriptPistola;
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
        scriptPistola = GameObject.Find("Pistol").GetComponent<ScriptPistola>();
        desaparecerPowerUp();
        scriptPistola.municionTotal += 30;
        SpawnerMunicion spawnerScript = GameObject.Find("SpawnerMunicion").GetComponent<SpawnerMunicion>();
        spawnerScript.objetoRecogido = true;
    }

    private void desaparecerPowerUp()
    {
        Destroy(gameObject);
    }
        
}
