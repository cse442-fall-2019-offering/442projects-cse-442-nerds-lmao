using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public float timeBetweenWaves = 11f;
    public float countdown = 11f;

    public Text waveCountDownText;
    public Text waveNumberText;

    public Transform freshmanEnemyPrefab;
    public Transform sophmoreEnemyPrefab;
    public Transform juniorEnemyPrefab;
    public Transform seniorEnemyPrefab;
    public Transform spawnPoint;



    [SerializeField]

    private int waveNumber = 0;
    Transform[] enemies = new Transform[4];

    void Start() {
        enemies[0] =freshmanEnemyPrefab;
        enemies[1] = sophmoreEnemyPrefab;
        enemies[2] = juniorEnemyPrefab;
        enemies[3] = seniorEnemyPrefab;

    }

    void Update()
    {

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            SpawnWave();
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountDownText.text = Mathf.Floor(countdown).ToString();

    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        waveNumberText.text = waveNumber.ToString();

        for (int i = 0; i <= waveNumber; i++)
        {
            foreach (Transform enemy in enemies)
            {
                SpawnEnemy(juniorEnemyPrefab);
                yield return new WaitForSeconds(0.5f);
            }
        }

    }

    void SpawnEnemy(Transform enemyPrefab)
    {
        enemyPrefab.tag = "Enemy";
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    }
}
