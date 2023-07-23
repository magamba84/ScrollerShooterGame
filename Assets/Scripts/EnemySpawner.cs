using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory enemyFactory;

    [SerializeField] private List<Transform> spawnPoints;

    [SerializeField] private Transform borderPoint;

    private FloatRange spawnTimeoutRange;

    private List<EnemyController> spawnedEnemies = new List<EnemyController>();

    private void Start()
    {
        var settings = GameSettings.Instance;
        spawnTimeoutRange = settings.EnemySpawnTimeoutRange;
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        do
        {
            yield return new WaitForSeconds(Random.Range(spawnTimeoutRange.min, spawnTimeoutRange.max));
            SpawnEnemy();
        }
        while (true);
    }

    private void SpawnEnemy()
    {
        var go = enemyFactory.CreateEnemy();
        var startPos = spawnPoints[Random.Range(0, spawnPoints.Count)];
        go.transform.position = startPos.transform.position;

        var enemy = go.GetComponent<EnemyController>();
        enemy.Init(borderPoint);

        spawnedEnemies.Add(enemy);
        enemy.Destroyed -= OnEnemyDestroyed;
        enemy.Destroyed += OnEnemyDestroyed;
    }

    private void OnEnemyDestroyed(EnemyController enemy)
    {
        if(spawnedEnemies.Contains(enemy))
            spawnedEnemies.Remove(enemy);
    }

    public List<EnemyController> GetEnemiesList() 
    {
        return spawnedEnemies;
    }
}
