using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public GameObject warningPrefab;

    public float spawnRange = 20f;
    public float spawnHeight = 20f;
    public float delayBeforeFall = 1.5f;

    public float spawnRate = 2f;

    void Start()
    {
        InvokeRepeating("SpawnMeteor", 1f, spawnRate);
    }

    void SpawnMeteor()
    {
        Vector3 randomPos = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            0,
            Random.Range(-spawnRange, spawnRange)
        );

        StartCoroutine(SpawnWithWarning(randomPos));
    }

    IEnumerator SpawnWithWarning(Vector3 pos)
    {
        // สร้างวงเตือน
        GameObject warning = Instantiate(warningPrefab, pos, Quaternion.identity);

        // รอก่อนตก
        yield return new WaitForSeconds(delayBeforeFall);

        // สร้าง Meteor
        Vector3 spawnPos = pos + Vector3.up * spawnHeight;
        Instantiate(meteorPrefab, spawnPos, Quaternion.identity);

        // ลบวงเตือน
        Destroy(warning);
    }
}