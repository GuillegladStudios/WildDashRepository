using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

public class LevelPartsSpawner : Singleton<LevelPartsSpawner>
{
    [SerializeField] List<GameObject> levelParts; //Lista de partes del nivel que se pueden generar
    [SerializeField] int defaultPoolCapacity = 3; //Capacidad por defecto de cada pool de objetos
    [SerializeField] int maxPoolCapacity = 5; //Capacidad máxima de cada pool de objetos

    private List<IObjectPool<GameObject>> objectPools = new List<IObjectPool<GameObject>>(); //Lista de pools de objetos

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene loaded event
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from scene loaded event
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetPools(); // Reset pools when a new scene is loaded
    }
    private void Start()
    {
        InitializePools(); // Initialize the pools when the script starts
    }
    private void InitializePools()
    {
        foreach (GameObject levelPart in levelParts)
        {
            if (levelPart != null)
            {
                objectPools.Add(new ObjectPool<GameObject>(
                    () => Instantiate(levelPart),
                    levelPart => levelPart.SetActive(true),
                    levelPart => levelPart.SetActive(false),
                    levelPart => Destroy(levelPart),
                    true,
                    defaultPoolCapacity,
                    maxPoolCapacity)
                    );
            }
        }
    }
    private void ResetPools()
    {
        foreach (var pool in objectPools)
        {
            pool.Clear(); // Clear the pool when a new scene is loaded
        }
        objectPools.Clear(); // Clear the list of pools
        InitializePools();
    }

    public void SpawnRandomLevelPart(Transform spawnTransform)
    {
        int randomPartNumber = Random.Range(0, objectPools.Count);// Get a random index from the pools list
        var poolForSpawning = objectPools[randomPartNumber]; // Get the pool for the random part

        var partToSpawn = poolForSpawning.Get(); // Get an object from the pool
        partToSpawn.transform.position = spawnTransform.position; // Set the position of the object
        var trigger = partToSpawn.GetComponent<LevelPartsSpawnerTrigger>(); // Get the Trigger component from the object
        trigger.Pool = poolForSpawning; // Set the pool for the trigger
    }
}
