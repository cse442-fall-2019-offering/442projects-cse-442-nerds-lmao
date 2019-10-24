using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public float timeBetweenWaves = 11f;
    public float countdown = 11f;

    public Transform enemyPrefab;
    public Transform spawnPoint;



    [SerializeField]

    private int waveNumber = 1;

    void Update()
    {

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            SpawnWave();
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i <= waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        Debug.Log("Wave Incoming!");
        waveNumber++;

    }

    void SpawnEnemy()
    {
        enemyPrefab.tag = "Enemy";
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
