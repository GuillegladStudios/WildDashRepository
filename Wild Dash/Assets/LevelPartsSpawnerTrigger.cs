using UnityEngine;
using UnityEngine.Pool;

public class LevelPartsSpawnerTrigger : MonoBehaviour
{
    [SerializeField] private Transform spawnTransform; // Transform where the level part will be spawned
    [HideInInspector] public IObjectPool<GameObject> Pool; // Pool from which the level part will be spawned

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LevelPartsSpawner.Instance.SpawnRandomLevelPart(spawnTransform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;
        if (Pool == null)
        {
            transform.parent.gameObject.SetActive(false); // Disable the parent object if the pool is null
            return;
        }
        Pool.Release(gameObject); // Release the game object back to the pool 

    }
}
