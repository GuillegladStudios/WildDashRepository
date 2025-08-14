using Cinemachine;
using UnityEngine;

public class VibraCamScript : MonoBehaviour
{
    [SerializeField] private float vibraTiempoTotal; // Tiempo total de vibraci�n
    [SerializeField] private float intensidadVibra; // Intensidad de la vibraci�n
    [SerializeField] private float frecuenciaVibra; // Frecuencia de la vibraci�n

    private CinemachineVirtualCamera _camaraVirtual; // Referencia a la c�mara virtual de Cinemachine
    private float vibraTiempo = 0f; // Tiempo acumulado de vibraci�n

    public void VibraCamara() // M�todo p�blico para iniciar la vibraci�n de la c�mara
    {
        // Obtener la c�mara virtual activa
        _camaraVirtual = (CinemachineVirtualCamera)CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera;

        // Obtener el componente de vibraci�n de la c�mara virtual
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = _camaraVirtual.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensidadVibra; // Establecer la intensidad de la vibraci�n
        cinemachineBasicMultiChannelPerlin.m_FrequencyGain = frecuenciaVibra; // Establecer la frecuencia de la vibraci�n

        vibraTiempo = vibraTiempoTotal; // Reiniciar el tiempo de vibraci�n
    }

    private void Update()
    {
        if (vibraTiempo > 0) // Verificar si el tiempo de vibraci�n es mayor que cero
        {
            // Reducir el tiempo de vibraci�n
            vibraTiempo -= Time.deltaTime;

            // Obtener el componente de vibraci�n de la c�mara virtual
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = _camaraVirtual.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            // Interpolar la intensidad de la vibraci�n
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(intensidadVibra, 0f, 1 - vibraTiempo / vibraTiempoTotal);

            // Interpolar la frecuencia de la vibraci�n
            cinemachineBasicMultiChannelPerlin.m_FrequencyGain = Mathf.Lerp(frecuenciaVibra, 0f, 1 - vibraTiempo / vibraTiempoTotal);

        }
    }
}
