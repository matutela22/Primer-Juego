using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarObjetos : MonoBehaviour
{
    private bool frenteAObjeto = false;
    private GameObject objetoAAgarrar;
    private bool puedoAgarrar = true;
    public GameObject pistola;
    public GameObject textoPickUp;
    public bool cambioEscena = false;


    private void Update()
    {
    
        if (frenteAObjeto)
        {
            if (Input.GetButtonDown("E"))
            {
                if (objetoAAgarrar.name.Substring(0, 6) == "Pistol")
                      {
                        pistola.SetActive(true);
                        cambioEscena = true;
                      }
            Destroy(objetoAAgarrar);

            puedoAgarrar = false;
            }
        }
    
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Interactuable" && puedoAgarrar)
        {
            Debug.Log(other.name);
            textoPickUp.SetActive(true);
            frenteAObjeto = true;

            objetoAAgarrar = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        textoPickUp.SetActive(false);
        frenteAObjeto = false;
    }

}
