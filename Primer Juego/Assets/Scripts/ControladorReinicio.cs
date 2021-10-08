using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorReinicio : MonoBehaviour
{

    public ControlMirarCamara camara;
    private float sensibilidadActual;

    public float tiempoTemporizador = 20;
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

        PasarTiempoTemporizador();

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
            Restart();
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
    public void Restart()
    {
        SceneManager.LoadScene("PrimerEscenario");
        Time.timeScale = 1;
        BloquearMouse();
        juegoPausado = false;
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
    public void salirDelJuego()
    {
        Application.Quit();
    }

    void PasarTiempoTemporizador()
    {
        tiempoTemporizador -= Time.deltaTime;
        Text temp = (Text) temporizador.GetComponent(typeof(Text));
    temp.text = tiempoTemporizador.ToString("#") ;
    }


}
