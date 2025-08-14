using Cinemachine;
using UnityEngine;
public class CamaraZoomScript : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camaraCaminar; // Cámara para caminar
    [SerializeField] private CinemachineVirtualCamera camaraCorrer; // Cámara para correr
    public void ZoomIn()
    {
        Debug.Log("ZoomIn called"); // Log para depuración
        if (camaraCaminar != null && camaraCorrer != null) // Verifica que las cámaras no sean nulas
        {
            camaraCaminar.enabled = true; // Activa la cámara de caminar
            camaraCorrer.enabled = false; // Desactiva la cámara de correr
        }
    }
    public void ZoomOut()
    {
        Debug.Log("ZoomOut called"); // Log para depuración
        if (camaraCaminar != null && camaraCorrer != null) // Verifica que las cámaras no sean nulas
        {
            camaraCaminar.enabled = false; //Desactiva la cámara de caminar
            camaraCorrer.enabled = true; // Activa la cámara de correr
        }
    }
}