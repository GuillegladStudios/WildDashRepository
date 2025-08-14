using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class UpdateUIFromAtomVariable : MonoBehaviour
{
    [SerializeField] private IntVariable variable; // Variable a observar
    [SerializeField] private TextMeshProUGUI Text; // Componente de texto UI para mostrar el valor

    private void Start()
    {
        Text.text = variable.Value.ToString(); // Inicializar el texto con el valor de la variable
    }

    private void OnEnable()
    {
        variable.Changed.Register(UpdateUIText); // Registrar este script como observador de la variable
    }

    private void OnDisable()
    {
        variable.Changed.Unregister(UpdateUIText); // Desregistrar este script como observador de la variable
    }

    private void UpdateUIText(int obj)
    {
        Text.text = variable.Value.ToString(); // Actualizar el texto UI con el nuevo valor de la variable
    }
}
