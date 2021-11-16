using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedInvisibleBosque : MonoBehaviour
{
    public GameObject paredTrigger;
    private GameObject manos;
    // Start is called before the first frame update
    void Start()
    {
        manos = GameObject.Find("Manos");
    }

    // Update is called once per frame
    void Update()
    {
        AgarrarObjetos scriptManos = manos.GetComponent<AgarrarObjetos>();
        if (scriptManos.cambioEscena)
        {
            paredTrigger.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
