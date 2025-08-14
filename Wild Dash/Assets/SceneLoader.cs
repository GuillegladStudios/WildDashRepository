using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName; // Nombre de la escena a cargar
    // Se encarga de cargar una escena espec�fica cuando se llama al m�todo LoadScene
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName); // Carga la escena especificada
    }
}
