using Cinemachine;
using UnityEngine;

public class VibraCamScript : MonoBehaviour
{
    [SerializeField] private float vibraTiempoTotal; // Tiempo total de vibración
    [SerializeField] private float intensidadVibra; // Intensidad de la vibración
    [SerializeField] private float frecuenciaVibra; // Frecuencia de la vibración

    private CinemachineVirtualCamera _camaraVirtual; // Referencia a la cámara virtual de Cinemachine
    private float vibraTiempo = 0f; // Tiempo acumulado de vibración

    public void VibraCamara() // Método público para iniciar la vibración de la cámara
    {
        // Obtener la cámara virtual activa
        _camaraVirtual = (CinemachineVirtualCamera)CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera;

        // Obtener el componente de vibración de la cámara virtual
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = _camaraVirtual.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensidadVibra; // Establecer la intensidad de la vibración
        cinemachineBasicMultiChannelPerlin.m_FrequencyGain = frecuenciaVibra; // Establecer la frecuencia de la vibración

        vibraTiempo = vibraTiempoTotal; // Reiniciar el tiempo de vibración
    }

    private void Update()
    {
        if (vibraTiempo > 0) // Verificar si el tiempo de vibración es mayor que cero
        {
            // Reducir el tiempo de vibración
            vibraTiempo -= Time.deltaTime;

            // Obtener el componente de vibración de la cámara virtual
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = _camaraVirtual.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            // Interpolar la intensidad de la vibración
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(intensidadVibra, 0f, 1 - vibraTiempo / vibraTiempoTotal);

            // Interpolar la frecuencia de la vibración
            cinemachineBasicMultiChannelPerlin.m_FrequencyGain = Mathf.Lerp(frecuenciaVibra, 0f, 1 - vibraTiempo / vibraTiempoTotal);

        }
    }
}
