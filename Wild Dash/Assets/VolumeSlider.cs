using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider _volumeSlider; // Slider para controlar el volumen
    private void Awake()
    {
        _volumeSlider = GetComponent<Slider>(); // Obtener el componente Slider del GameObject
    }
    private void Start()
    {
        _volumeSlider.value = SaveManager.Instance.GetVolumen(); // Establecer el valor inicial del slider al volumen guardado

        _volumeSlider.onValueChanged.AddListener(SetVolume); // Añadir un listener para el evento de cambio de valor del slider
    }

    private void SetVolume(float volume)
    {
        AudioListener.volume = volume; // Establecer el volumen del AudioListener al valor del slider

        SaveManager.Instance.SaveVolumen(volume); // Guardar el volumen usando SaveManager
    }
    private void OnDestroy()
    {
        _volumeSlider.onValueChanged.RemoveListener(SetVolume); // Eliminar el listener al destruir el objeto
    }
}
