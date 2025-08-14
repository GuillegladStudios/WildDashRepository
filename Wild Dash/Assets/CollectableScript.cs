using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class CollectableScript : MonoBehaviour
{
    [SerializeField] private CollectableSO collectableData; // Referencia a los datos del coleccionable
    [SerializeField] private IntVariable puntajeJuego; // Variable para almacenar el puntaje del juego
    [SerializeField] private UnityEvent onTriggerEnter; // Evento para manejar la colisión

    private SpriteRenderer _spriteRendered; // Componente SpriteRenderer para mostrar el sprite del coleccionable

    private void Awake()
    {
        _spriteRendered = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        _spriteRendered.sprite = collectableData.CollectableSprite; // Asigna el sprite del coleccionable al SpriteRenderer
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Aumenta el puntaje del juego con el valor del coleccionable
            puntajeJuego.Value += collectableData.CollectablePoints;
            // Llama al evento de colisión
            onTriggerEnter?.Invoke();
            // Destruye el objeto coleccionable
            //gameObject.SetActive(false);
        }
    }
}
