using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnRate = 2f;
    public float areaSize = 20f;

    void Start()
    {
        InvokeRepeating("SpawnMeteor", 1f, spawnRate);
    }

    void SpawnMeteor()
    {
        Vector3 pos = new Vector3(
            Random.Range(-areaSize, areaSize),
            20f,
            Random.Range(-areaSize, areaSize)
        );

        Instantiate(meteorPrefab, pos, Quaternion.identity);
    }
}