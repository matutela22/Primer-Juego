using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptPistola : MonoBehaviour
{
    public float tiempoRecarga = 1f;
    public float tiempoEntreDisparos = 1f;

    public GameObject textoMuni;
    private int municionCargador = 30;
    public int municionTotal = 60;
    private Camera camaraPrimeraPersona;
    private GameObject manos;
    public bool municionEspecialActiva = false;
    private Animator anim;
    private bool estoyRecargando = false;
    private bool estoyDisparando = false;
    public GameObject sonidoDisparo;


    private void Start()
    {
        anim = GetComponent<Animator>();
        textoMuni.SetActive(true);
        manos = GameObject.Find("Manos");
    }
    void Update()
    {
        camaraPrimeraPersona = Camera.main;
        Text textoAmmo = (Text)textoMuni.GetComponent(typeof(Text));
        textoAmmo.text = municionCargador.ToString() + "/" + municionTotal.ToString();

        if (Input.GetButtonDown("R"))
        {
            StartCoroutine (Recargar());
        }

        if (Input.GetMouseButtonDown(0) && municionCargador > 0 && !estoyRecargando && !estoyDisparando)
        {
            StartCoroutine(Disparar());
        }
    }
        IEnumerator Recargar()
    {
        if (municionTotal > 0 && municionCargador != 30)
        {
            estoyRecargando = true;
            anim.Play("Recarga");
            yield return new WaitForSeconds(tiempoRecarga);
            while (municionTotal > 0 && municionCargador < 30)
            {
                municionTotal -= 1;
                municionCargador += 1;
            }
            estoyRecargando = false;
        }
    }

        IEnumerator Disparar()
    {
        manos.SetActive(false);
        anim.Play("Disparo");
        Instantiate(sonidoDisparo);
        estoyDisparando = true;
        municionCargador -= 1;
        Ray rayo = camaraPrimeraPersona.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(rayo, out hit) && hit.distance < 15)
        {
            if (hit.collider.CompareTag("Enemigo"))
            {

                GameObject objetoTocado = GameObject.Find(hit.transform.name);
                ControlEnemigos scriptObjetoTocado = objetoTocado.GetComponent<ControlEnemigos>();
                if (scriptObjetoTocado != null)
                {

                    scriptObjetoTocado.recibirDaño(25);
                    if (municionEspecialActiva)
                    {
                        GameObject jugador = GameObject.Find("Jugador");
                        ControlJugador scriptJugador = jugador.GetComponent<ControlJugador>();
                        scriptJugador.hp += 25;
                    }

                }

            }
        }
        yield return new WaitForSeconds(tiempoEntreDisparos);
        estoyDisparando = false;        
        manos.SetActive(true);
    }
}
