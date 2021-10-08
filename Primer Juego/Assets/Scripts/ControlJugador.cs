using UnityEngine;
using UnityEngine.UI;

public class ControlJugador : MonoBehaviour
{
    public GameObject textoVida;
    public ControladorReinicio controladorReinicio;

    public int hp = 100;

    public float rapidezDesplazamiento = 10.0f;
    public Camera camaraPrimeraPersona;


    public float velSalto;
    private bool puedoSaltar = true;
    private int contadorSaltos = 0;
    private Rigidbody rb;

    private int municionCargador = 30;
    public int municionTotal = 60;
    public Text municion;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        textoVida.SetActive(true);

    }

    void Update()
    {

        Text textoHP = (Text)textoVida.GetComponent(typeof(Text));
        textoHP.text = hp.ToString();

        municion.text = municionCargador.ToString() + "/" + municionTotal.ToString();


        float movimientoAdelanteAtras = Input.GetAxis("Vertical") * rapidezDesplazamiento;
        float movimientoCostados = Input.GetAxis("Horizontal") * rapidezDesplazamiento;

        movimientoAdelanteAtras *= Time.deltaTime;
        movimientoCostados *= Time.deltaTime;

        transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras);

        if (hp <= 0)
        {
            GameOver();
        }
        //Recarga
        if (Input.GetButtonDown ("R"))
        {
            Recargar();
        }

        //Disparo
        if (Input.GetMouseButtonDown(0) && municionCargador > 0)
        {

            municionCargador -= 1;
            Ray rayo = camaraPrimeraPersona.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            if (Physics.Raycast(rayo, out hit) && hit.distance < 5)
            {
                //Si el nombre del objeto inicia con las primeras 3 "Bot"
                if (hit.collider.name.Substring(0,3) == "Bot")
                {
                    //Buscamos al bot
                    GameObject objetoTocado = GameObject.Find(hit.transform.name);
                    //Buscamos el script del bot
                    ControlBot scriptObjetoTocado = (ControlBot)objetoTocado.GetComponent(typeof(ControlBot));
                    
                    //Si el script existe
                    if (scriptObjetoTocado != null)
                    { 
                        //Le decimos al script del bot que reciba daño
                        scriptObjetoTocado.recibirDaño();
                    }
                }
            }
        }

        if (Input.GetButtonDown("Jump") && puedoSaltar)
        {
            rb.velocity += new Vector3(0f, velSalto, 0f);
            contadorSaltos++;
        }

        if (contadorSaltos == 2)
        {
            puedoSaltar = false;
        }
}
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 8)
        {
            puedoSaltar = true;
            contadorSaltos = 0;
        }

        if (other.gameObject.layer == 9)
        {
            ganarPartida();
        }

        if (other.gameObject.name.Substring(0, 3) == "Bot")
        {
            hp -= 25;
            Debug.Log(hp);
        }

    }

    private void Recargar()
    {
        if (municionTotal > 0 && municionCargador != 30)
        {
            while (municionTotal > 0 && municionCargador < 30)
            {
                municionTotal -= 1;
                municionCargador += 1;
            }
        }
    }

    void ganarPartida()
    {
        controladorReinicio.GanarPartida();
    }

    public void GameOver()
    {
        controladorReinicio.GameOver();
    }
}
