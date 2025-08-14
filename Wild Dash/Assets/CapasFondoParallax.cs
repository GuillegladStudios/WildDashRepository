using UnityEngine;

public class CapasFondoParallax : MonoBehaviour
{
    [SerializeField] private float layerEffectMultiplier; // Controla la velocidad de desplazamiento de cada capa relativa a la c�mara

    private Transform _camera; // Referencia a la c�mara principal
    private Vector3 _lastCameraPosition; // Posici�n anterior de la c�mara para calcular el desplazamiento
    private float _textureSize; // Tama�o de la textura de fondo 

    private void Start()
    {
        _camera = Camera.main.transform; // Obtener la c�mara principal
        _lastCameraPosition = _camera.position; // Inicializar la posici�n anterior de la c�mara

        Sprite sprite = GetComponent<SpriteRenderer>().sprite; // Obtener el sprite del fondo
        Texture2D texture = sprite.texture; // Obtener la textura del sprite
        _textureSize = texture.width / sprite.pixelsPerUnit; // Calcular el tama�o de la textura en unidades del mundo

    }
    private void LateUpdate()
    {
        Vector3 deltaMovement = _camera.position - _lastCameraPosition; // Calcular el desplazamiento de la c�mara
        transform.position += new Vector3(deltaMovement.x * layerEffectMultiplier, 0); // Desplazar la capa en funci�n del movimiento de la c�mara y el multiplicador

        _lastCameraPosition = _camera.position; // Actualizar la posici�n anterior de la c�mara

        float distanceFromCamera = _camera.position.x - transform.position.x; // Calcular la distancia desde la c�mara a la capa

        if (Mathf.Abs(distanceFromCamera) > _textureSize) // Si la distancia es mayor que el tama�o de la textura
        {
            float offsetPositionX = Mathf.Round(distanceFromCamera / _textureSize) * _textureSize; // Calcular el desplazamiento necesario para alinear la capa con la c�mara
            transform.position = new Vector3(transform.position.x + offsetPositionX, transform.position.y); // Actualizar la posici�n de la capa
        }
    }
}
