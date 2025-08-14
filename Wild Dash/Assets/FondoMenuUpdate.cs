using UnityEngine;

public class FondoMenuUpdate : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;

    private void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }
}