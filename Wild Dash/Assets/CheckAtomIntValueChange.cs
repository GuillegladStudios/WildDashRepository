using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

public class CheckAtomIntValueChange : MonoBehaviour
{
    [SerializeField] private IntVariable variable; // Referencia al IntVariable que se va a observar
    [SerializeField] private UnityEvent onValueIncrease; // Evento a disparar cuando el valor aumenta
    [SerializeField] private UnityEvent onValueDecrease; // Evento a disparar cuando el valor disminuye

    public void CheckValueChange()
    {
        if (variable.Value > variable.OldValue) // Comprobar si el valor ha aumentado
        {
            onValueIncrease?.Invoke(); // Disparar el evento de aumento
        }
        else if (variable.Value < variable.OldValue) // Comprobar si el valor ha disminuido
        {
            onValueDecrease?.Invoke(); // Disparar el evento de disminución
        }
    }
}
