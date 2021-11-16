using UnityEngine;
using UnityEngine.UI;

public class ControlJugador : MonoBehaviour
{
    public GameObject textoVida;
    public ControladorReinicio controladorReinicio;

    public int hp = 100;

    public float rapidezDesplazamiento = 10.0f;

    public float velSalto;
    private bool puedoSaltar = true;
    private int contadorSaltos = 0;
    private Rigidbody rb;



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

        float movimientoAdelanteAtras = Input.GetAxis("Vertical") * rapidezDesplazamiento;
        float movimientoCostados = Input.GetAxis("Horizontal") * rapidezDesplazamiento;

        movimientoAdelanteAtras *= Time.deltaTime;
        movimientoCostados *= Time.deltaTime;
        transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras);
        

        if (hp <= 0)
        {
            GameOver();
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
            recibirDaño();
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

    public void recibirDaño()
    {
        hp -= 25;
    }
}
