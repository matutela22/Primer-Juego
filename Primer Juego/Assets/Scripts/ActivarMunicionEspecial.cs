using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarMunicionEspecial : MonoBehaviour
{

    public GameObject HUDMunEspecialActivada;
    public GameObject HUDMunEspecialDesactivada;
    void Start()
    {
        HUDMunEspecialDesactivada.SetActive(true);
    }

    // Update is called once per frame
    void Update()
       {
           if (Input.GetKeyDown(KeyCode.Q))
           {
            HUDMunEspecialDesactivada.SetActive(false);
            HUDMunEspecialActivada.SetActive(true);

            StartCoroutine(ActivarMunicion());
        }
    }

       IEnumerator ActivarMunicion()
       {
           Debug.Log("Municion Especial Activada");
           GameObject pistola = GameObject.Find("Pistol");
           ScriptPistola scriptPistola = pistola.GetComponent<ScriptPistola>();

           scriptPistola.municionEspecialActiva = true;
           Debug.Log(scriptPistola.municionEspecialActiva);
           yield return new WaitForSeconds(2);
           HUDMunEspecialDesactivada.SetActive(true);
           HUDMunEspecialActivada.SetActive(false);
           scriptPistola.municionEspecialActiva = false;
           Debug.Log(scriptPistola.municionEspecialActiva);

       }


}
