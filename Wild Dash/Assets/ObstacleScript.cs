using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class ObstacleScript : MonoBehaviour
{
    [SerializeField] private ObstacleSO obstacleData; // Referencia a los datos del obst�culo
    [SerializeField] private UnityEvent onTriggerEnter; // Evento para manejar la colisi�n
    private SpriteRenderer _spriteRenderer; // Componente SpriteRenderer para mostrar el sprite del obst�culo
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        _spriteRenderer.sprite = obstacleData.ObstacleSprite; // Asigna el sprite del obst�culo al SpriteRenderer
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<DamageScript>()?.TakeDamage(obstacleData.ObstacleDamage); // Aplica da�o al jugador
            // Llama al evento de colisi�n
            onTriggerEnter?.Invoke();
            // Destruye el objeto obst�culo
            //gameObject.SetActive(false);
        }
    }
}
