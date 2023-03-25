using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;

    private int _currentWaveIndex = 0;

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        Wave currentWave = waves[_currentWaveIndex];

        foreach (EnemyUnit enemyUnit in currentWave.enemyUnits)
        {
            for (int i = 0; i < enemyUnit.enemyCount; i++)
            {
                SpawnEnemy(enemyUnit.enemyPrefab);
                yield return new WaitForSeconds(currentWave.spawnInterval);
            }
        }

        _currentWaveIndex++;

        if (_currentWaveIndex < waves.Length)
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
}