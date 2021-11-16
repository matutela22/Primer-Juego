using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GestorPersistencia : MonoBehaviour
{
    public static GestorPersistencia instancia;
    public DataPersistencia data;
    string archivoDatos = "save.dat";

    private void Awake()
    {
        if (instancia == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instancia = this;
        }
        else if (instancia != this)
            Destroy(this.gameObject);

        CargarDataPersistencia();
    }


    public void GuardarDataPersistencia()
    {
        ContadorPuntaje scriptPuntaje = GameObject.Find("ContadorPuntaje").GetComponent<ContadorPuntaje>();
        int puntaje = scriptPuntaje.puntajeActual;
        if (puntaje > data.puntajeMaximo)
        {
            data = new DataPersistencia(puntaje);
            Debug.Log(puntaje);
            string filePath = Application.persistentDataPath + "/" + archivoDatos;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(filePath);
            bf.Serialize(file, data);
            file.Close();
            Debug.Log("Datos guardados");
        }
    }

    public void CargarDataPersistencia()
    {
        string filePath = Application.persistentDataPath + "/" + archivoDatos;
        Debug.Log(filePath);
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(filePath))
        {
            FileStream file = File.Open(filePath, FileMode.Open);
            DataPersistencia cargado = (DataPersistencia)bf.Deserialize(file);
            data = cargado;
            file.Close();
            Debug.Log("Datos cargados");
        }
    }
}