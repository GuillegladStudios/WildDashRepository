using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private IntVariable puntos; // Variable para almacenar los puntos del jugador
    public void PauseGame()
    {
        Time.timeScale = 0f; // Pausa el juego
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Reanuda el juego
    }
    public void RestartCurrentScene()
    {
        var currentScene = SceneManager.GetActiveScene().name; // Obtiene la escena actual
        SceneManager.LoadScene(currentScene); // Reinicia la escena actual
        puntos.Value = 0; // Reinicia los puntos a 0
    }
    public void OnApplicationQuit()
    {
        Application.Quit(); // Cierra la aplicación
    }
    private void Start()
    {
        puntos.Value = 0; // Inicializa los puntos a 0 al iniciar el juego

        AudioListener.volume = SaveManager.Instance.GetVolumen(); // Establece el volumen del juego al valor guardado

        float refreshRate = Screen.currentResolution.refreshRateRatio.numerator - (float)Screen.currentResolution.refreshRateRatio.denominator; // Obtiene el refresh rate de la pantalla
        Application.targetFrameRate = Mathf.RoundToInt(refreshRate); // Establece el target frame rate al refresh rate de la pantalla
    }
}
