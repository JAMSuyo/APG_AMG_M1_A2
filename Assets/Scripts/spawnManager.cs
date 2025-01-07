using System.Collections;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public Transform cannonPosition;
    public int waveCount = 4;
    public float timeBetweenWaves = 2f;
    public float timeBetweenEnemies = 1f;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        for (int i = 0; i < waveCount; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(timeBetweenEnemies);
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        enemy.GetComponent<enemyMovement>().cannon = cannonPosition;
    }
}
