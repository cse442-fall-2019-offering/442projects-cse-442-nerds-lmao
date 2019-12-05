using System.Collections;
using UnityEngine;
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
    public Transform pipeEnemyPrefab;
    public Transform coatEnemyPrefab;
    public Transform darkwingEnemyPrefab;
    public Transform snakeEnemyPrefab;
    public Transform spawnPoint;
    private bool waveStarted = false;


    [SerializeField]

    private int waveNumber = 0;
    Transform[] enemies = new Transform[11];

    void Start()
    {
        enemies[0] = freshmanEnemyPrefab;
        enemies[1] = sophmoreEnemyPrefab;
        enemies[2] = juniorEnemyPrefab;
        enemies[3] = seniorEnemyPrefab;
        enemies[4] = pipeEnemyPrefab;
        enemies[5] = coatEnemyPrefab;
        enemies[6] = darkwingEnemyPrefab;
        enemies[7] = snakeEnemyPrefab;
        enemies[8] = darkwingEnemyPrefab;
        enemies[9] = darkwingEnemyPrefab;
        enemies[10] = snakeEnemyPrefab;

    }

    void Update()
    {

        if (waveStarted & EnemiesAlive == 0)
        {
            waveNumber++;
            PlayerStats.Rounds = waveNumber;

            if (waveNumber <= 10 & PlayerStats.Lives > 0) {
                waveNumberText.text = waveNumber.ToString();
            }
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

        if (waveNumber <= 10 & PlayerStats.Lives > 0)
        {
            waveCountDownText.text = Mathf.Floor(countdown).ToString();
        }

    }

    IEnumerator SpawnWave()
    {

        for (int i = 0; i <= waveNumber + PlayerPrefs.GetInt("difficulty", -1); i++)
        {
            SpawnEnemy(enemies[Random.Range(0, waveNumber)]);
            yield return new WaitForSeconds(0.5f);

        }

    }

    void SpawnEnemy(Transform enemyPrefab)
    {
        EnemiesAlive++;
        enemyPrefab.tag = "Enemy";

        Transform currentEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        currentEnemy.GetComponent<Enemy>().startSpeed += (float)(0.1 * waveNumber + 0.4 * PlayerPrefs.GetInt("difficulty", -1) + 0.2 * PlayerStats.levelNumber);
        currentEnemy.GetComponent<Enemy>().startHealth += (float)(150 * PlayerPrefs.GetInt("difficulty", -1) + waveNumber * 20 + 50 * PlayerStats.levelNumber);

    }
}
