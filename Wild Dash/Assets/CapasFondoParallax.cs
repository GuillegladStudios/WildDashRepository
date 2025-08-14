using UnityEngine;

public class CapasFondoParallax : MonoBehaviour
{
    [SerializeField] private float layerEffectMultiplier; // Controla la velocidad de desplazamiento de cada capa relativa a la cámara

    private Transform _camera; // Referencia a la cámara principal
    private Vector3 _lastCameraPosition; // Posición anterior de la cámara para calcular el desplazamiento
    private float _textureSize; // Tamaño de la textura de fondo 

    private void Start()
    {
        _camera = Camera.main.transform; // Obtener la cámara principal
        _lastCameraPosition = _camera.position; // Inicializar la posición anterior de la cámara

        Sprite sprite = GetComponent<SpriteRenderer>().sprite; // Obtener el sprite del fondo
        Texture2D texture = sprite.texture; // Obtener la textura del sprite
        _textureSize = texture.width / sprite.pixelsPerUnit; // Calcular el tamaño de la textura en unidades del mundo

    }
    private void LateUpdate()
    {
        Vector3 deltaMovement = _camera.position - _lastCameraPosition; // Calcular el desplazamiento de la cámara
        transform.position += new Vector3(deltaMovement.x * layerEffectMultiplier, 0); // Desplazar la capa en función del movimiento de la cámara y el multiplicador

        _lastCameraPosition = _camera.position; // Actualizar la posición anterior de la cámara

        float distanceFromCamera = _camera.position.x - transform.position.x; // Calcular la distancia desde la cámara a la capa

        if (Mathf.Abs(distanceFromCamera) > _textureSize) // Si la distancia es mayor que el tamaño de la textura
        {
            float offsetPositionX = Mathf.Round(distanceFromCamera / _textureSize) * _textureSize; // Calcular el desplazamiento necesario para alinear la capa con la cámara
            transform.position = new Vector3(transform.position.x + offsetPositionX, transform.position.y); // Actualizar la posición de la capa
        }
    }
}
