using Cinemachine;
using UnityEngine;
public class CamaraZoomScript : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camaraCaminar; // C�mara para caminar
    [SerializeField] private CinemachineVirtualCamera camaraCorrer; // C�mara para correr
    public void ZoomIn()
    {
        Debug.Log("ZoomIn called"); // Log para depuraci�n
        if (camaraCaminar != null && camaraCorrer != null) // Verifica que las c�maras no sean nulas
        {
            camaraCaminar.enabled = true; // Activa la c�mara de caminar
            camaraCorrer.enabled = false; // Desactiva la c�mara de correr
        }
    }
    public void ZoomOut()
    {
        Debug.Log("ZoomOut called"); // Log para depuraci�n
        if (camaraCaminar != null && camaraCorrer != null) // Verifica que las c�maras no sean nulas
        {
            camaraCaminar.enabled = false; //Desactiva la c�mara de caminar
            camaraCorrer.enabled = true; // Activa la c�mara de correr
        }
    }
}