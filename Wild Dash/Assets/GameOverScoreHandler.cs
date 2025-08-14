using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class GameOverScoreHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI puntajeMasAlto; // UI para mostrar el puntaje m�s alto

    [SerializeField] private TextMeshProUGUI mejorPuntaje; // UI para mostrar el mejor puntaje del jugador

    [SerializeField] private IntVariable score; // Variable que almacena el puntaje actual del jugador

    public void UpdateScoreUI()
    {
        puntajeMasAlto.text = "Puntaje M�s Alto: " + score.Value.ToString(); // Actualiza el texto del puntaje m�s alto

        mejorPuntaje.text = "Mejor Puntaje: " + SaveManager.Instance.GetPuntajeMasAlto().ToString(); // Actualiza el texto del mejor puntaje
    }
}