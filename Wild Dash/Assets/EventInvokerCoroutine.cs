using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EventInvokerCoroutine : MonoBehaviour
{
    [SerializeField] private float couroutineTimer = 0f; // Tiempo en segundos entre invocaciones del evento
    [SerializeField] private UnityEvent couroutineEvent; // Evento a invocar

    private WaitForSeconds _timer; // Variable para esperar el tiempo especificado
    private void Start()
    {
        _timer = new WaitForSeconds(couroutineTimer); // Inicializa el temporizador con el tiempo especificado
    }

    public void StartCouroutine()
    {
        StartCoroutine(EventCoroutine()); // Inicia la corrutina
    }
    private IEnumerator EventCoroutine()
    {
        yield return _timer; // Espera el tiempo especificado
        couroutineEvent?.Invoke(); // Invoca el evento si no es nulo
    }
    private void OnDestroy()
    {
        StopAllCoroutines(); // Detiene todas las corrutinas al destruir el objeto
    }
}
