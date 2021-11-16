using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorReinicio : MonoBehaviour
{

    public ControlMirarCamara camara;
    private float sensibilidadActual;

    public float tiempoTemporizador = 180;
    public GameObject temporizador;
    public GameObject menuVictoria;
    public GameObject menuDerrota;
    public GameObject menuPausa;
    private bool juegoPausado = false;
    private bool gameOver = false;

    void Start()
    {
        sensibilidadActual = camara.sensibilidad;
        Time.timeScale = 1;
        temporizador.SetActive(true);
        Text temp = (Text)temporizador.GetComponent(typeof(Text));
        temp.text = tiempoTemporizador.ToString();
    }
    void Update()

    {


        if (tiempoTemporizador <= 0)
        {
            GameOver();
        }

        if (Input.GetButtonDown("Cancel") && !gameOver)
        {

           if (juegoPausado)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }            

        if (camara.gameObject.transform.position.y <= -4f)
        {
            VolverAlMenu();
        }

    }


    void Pause()
    {
        DesbloquearMouse();
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        juegoPausado = true;
    }
    public void Resume()
    {
        BloquearMouse();
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        juegoPausado = false;
    }
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuStart");
    }


    void DesbloquearMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        sensibilidadActual = camara.sensibilidad;
        camara.sensibilidad = 0f;
    }

    void BloquearMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        camara.sensibilidad = sensibilidadActual;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver = true;
        DesbloquearMouse();
        menuDerrota.SetActive(true);

    }

    public void GanarPartida()
    {
        gameOver = true;
        DesbloquearMouse();
        Time.timeScale = 0;
        menuVictoria.SetActive(true);
    }

    void PasarTiempoTemporizador()
    {
        tiempoTemporizador -= Time.deltaTime;
        Text temp = (Text) temporizador.GetComponent(typeof(Text));
    temp.text = tiempoTemporizador.ToString("#") ;
    }


}
