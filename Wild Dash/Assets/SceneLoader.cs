using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName; // Nombre de la escena a cargar
    // Se encarga de cargar una escena específica cuando se llama al método LoadScene
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName); // Carga la escena especificada
    }
}
