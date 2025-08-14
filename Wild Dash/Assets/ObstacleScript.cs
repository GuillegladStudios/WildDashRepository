using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class ObstacleScript : MonoBehaviour
{
    [SerializeField] private ObstacleSO obstacleData; // Referencia a los datos del obstáculo
    [SerializeField] private UnityEvent onTriggerEnter; // Evento para manejar la colisión
    private SpriteRenderer _spriteRenderer; // Componente SpriteRenderer para mostrar el sprite del obstáculo
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        _spriteRenderer.sprite = obstacleData.ObstacleSprite; // Asigna el sprite del obstáculo al SpriteRenderer
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<DamageScript>()?.TakeDamage(obstacleData.ObstacleDamage); // Aplica daño al jugador
            // Llama al evento de colisión
            onTriggerEnter?.Invoke();
            // Destruye el objeto obstáculo
            //gameObject.SetActive(false);
        }
    }
}
