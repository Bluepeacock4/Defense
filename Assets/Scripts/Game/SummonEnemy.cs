using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    //[SerializeField] private int enemyCount;          // 웨이브에서 출현할 적의 수, 지금은 스테이지 난이도와 동일하게 설정됨
    [SerializeField] private float spawnDelay;
    [SerializeField] private float maintenanceTime;     // 웨이브 전 대기시간
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(maintenanceTime);

        for (int i = 0; i < GameManager.Instance.stageLevel; i++)
        {
            Instantiate(enemyPrefab, spawnPoints[Random.Range(0, 4)].position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
