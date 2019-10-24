using System.Collections;
using UnityEngine;
using UnityEngine.UI;

using System.Collections;

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
    private bool waveStarted = false;


    [SerializeField]

    private int waveNumber = 0;
    Transform[] enemies = new Transform[4];

    void Start()
    {
        enemies[0] = freshmanEnemyPrefab;
        enemies[1] = sophmoreEnemyPrefab;
        enemies[2] = juniorEnemyPrefab;
        enemies[3] = seniorEnemyPrefab;

    }

    void Update()
    {
        if (GameManager.GameIsOver)
        {
            return;
        }

        if (waveStarted & EnemiesAlive == 0)
        {
            waveNumber++;
            waveNumberText.text = waveNumber.ToString();
            countdown = timeBetweenWaves;
            waveStarted = false;
            return;
        }

        if (waveStarted)
        {
            return;
        }



        if (countdown <= 0f)
        {
            waveStarted = true;
            StartCoroutine(SpawnWave());
            SpawnWave();
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountDownText.text = Mathf.Floor(countdown).ToString();

    }

    IEnumerator SpawnWave()
    {

        for (int i = 0; i <= waveNumber; i++)
        {
            SpawnEnemy(enemies[Random.Range(0, 4)]);
            yield return new WaitForSeconds(0.5f);

        }

        for (int i = 0; i <= 20; i++)
        {

            if (Random.Range(0, 4) == 3)
            {
                Debug.Log("Annen");
            }
        }
    }

    void SpawnEnemy(Transform enemyPrefab)
    {
        EnemiesAlive++;
        enemyPrefab.tag = "Enemy";
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    }
}
