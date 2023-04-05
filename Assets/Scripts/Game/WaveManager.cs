using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;
    public Slider waveProgressBar;
    public float delayTime;
    public GameObject[] endingObject;
    public CostManager costManager;

    private int currentWaveIndex = 0;
    [SerializeField]
    private int totalEnemy = 0;
    private int spawnedEnemy = 0;

    private void Start()
    {
        StartCoroutine(StartDelay());
        FindTotalEnemy();
    }

    private void Update()
    {
        UpdateWaveProgress(spawnedEnemy, totalEnemy);
        CheckClear();
    }

    private void FindTotalEnemy()
    {
        foreach (Wave wave in waves)
        {
            foreach (EnemyUnit enemyUnit in wave.enemyUnits)
            {
                totalEnemy += enemyUnit.enemyCount;
            }
        }
    }

    private IEnumerator SpawnWave()
    {
        Wave currentWave = waves[currentWaveIndex];

        foreach (EnemyUnit enemyUnit in currentWave.enemyUnits)
        {
            for (int i = 0; i < enemyUnit.enemyCount; i++)
            {
                SpawnEnemy(enemyUnit.enemyPrefab);
                spawnedEnemy++;
                yield return new WaitForSeconds(currentWave.spawnInterval);
            }
        }

        currentWaveIndex++;

        if (currentWaveIndex < waves.Length)
        {
            yield return new WaitForSeconds(currentWave.waveInterval);
            StartCoroutine(SpawnWave());
        }
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    private void UpdateWaveProgress(int spawnedEnemy, int totalEnemy)
    {
        float progress = (float)spawnedEnemy / (float)totalEnemy;
        waveProgressBar.value = progress;
    }

    [System.Serializable]
    public class Wave
    {
        public EnemyUnit[] enemyUnits;
        public float spawnInterval;
        public float waveInterval;
    }

    [System.Serializable]
    public class EnemyUnit
    {
        public GameObject enemyPrefab;
        public int enemyCount;
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(SpawnWave());
    }

    void CheckClear()
    {
        if (GameManager.Instance.killCount == totalEnemy)
        {
            endingObject[0].SetActive(true);
            StopCoroutine(costManager.SpawnCost());
        }
    }
}