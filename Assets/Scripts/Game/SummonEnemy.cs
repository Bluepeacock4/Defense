using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    //[SerializeField] private int enemyCount;          // ���̺꿡�� ������ ���� ��, ������ �������� ���̵��� �����ϰ� ������
    [SerializeField] private float spawnDelay;
    [SerializeField] private float maintenanceTime;     // ���̺� �� ���ð�
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
