using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigos : MonoBehaviour
{
    public int hp;
    private GameObject jugador;
    public float distanciaObjetivo;
    public float RangoMaximoPermitido = 15;
    public float velocidadEnemigo;
    public int triggerAtaque;
    public RaycastHit disparo;
    private Animator anim;
    public GameObject proyectil;
    public GameObject boquillaArma;
    public float rangoAtaque;
    public LayerMask mascaraJugador;
    private Rigidbody rb;
    public float proximoDisparo;
    public float cadenciaDisparo;
    public float fuerzaDisparo;
    public GameObject particulasMuerte;
    public float tiempoEntreDisparos = 1f;
    private bool puedoDisparar = true;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        proximoDisparo = Time.time + cadenciaDisparo;
        jugador = GameObject.Find("Jugador");
    }
    void Update()
    {
        transform.LookAt(jugador.transform.position);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out disparo))
        {
            distanciaObjetivo = disparo.distance;
            if (distanciaObjetivo < RangoMaximoPermitido)
            {
                if (triggerAtaque == 0)
                {
                    anim.Play("MovimientoEnemigo");
                    velocidadEnemigo = 5;
                    rb.transform.position = Vector3.MoveTowards(transform.position, jugador.transform.position, velocidadEnemigo * Time.deltaTime);
                }
                else if (triggerAtaque == 1)
                {
                    if (puedoDisparar)
                    {
                        anim.Play("Disparo");
                    }
                }
            }
            else
            {
                velocidadEnemigo = 0;
                anim.Play("EnemigoIdle");
            }

            if (hp <= 0)
            {
                Morir();
            }
        }


        bool jugadorEnRango = Physics.CheckSphere(transform.position, rangoAtaque, mascaraJugador);
        if (jugadorEnRango)
        {
            triggerAtaque = 1;
        }
        else
        {
            triggerAtaque = 0;
        }
    }
    IEnumerator Disparar()
    {
        puedoDisparar = false;
        velocidadEnemigo = 0;
        GameObject pro = Instantiate(proyectil, boquillaArma.transform.position, Quaternion.identity);
            pro.SetActive(true);
            Vector3 direccionDisparo = jugador.transform.position - boquillaArma.transform.position;
            pro.transform.forward = direccionDisparo.normalized;
            pro.GetComponent<Rigidbody>().AddForce(direccionDisparo.normalized * fuerzaDisparo, ForceMode.Impulse);
            proximoDisparo = Time.time + cadenciaDisparo;

        yield return new WaitForSeconds(tiempoEntreDisparos);

        puedoDisparar = true;
    }
    public void recibirDaño(int dañoRecibido)
    {
        hp = hp - dañoRecibido;
    }

    public void Morir()
    {

        Spawner spawn = GameObject.Find("Spawner").GetComponent<Spawner>();
        spawn.enemigosMuertos++;
        ContadorPuntaje puntaje = GameObject.Find("ContadorPuntaje").GetComponent<ContadorPuntaje>();
        puntaje.puntajeActual += 1;
        if (spawn.enemigosMuertos >= spawn.cantidadEnemigosSpawneados)
        {
            spawn.ProximaOleada();
        }


        Instantiate(particulasMuerte, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
}

  