using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private EnemyFactory enemyFactory;

    [SerializeField] private List<Transform> spawnPoints;

    [SerializeField] private Transform borderPoint;

    private FloatRange spawnTimeoutRange;

    private List<EnemyController> spawnedEnemies = new List<EnemyController>();

    public void StartSpawn()
    {
        var settings = GameSettings.Instance;
        spawnTimeoutRange = settings.EnemySpawnTimeoutRange;
        StartCoroutine(SpawnCoroutine());
    }

    public void StopSpawn()
    { 
        StopAllCoroutines();
        foreach (var enemy in spawnedEnemies)
        {
            Destroy(enemy.gameObject);
        }
        spawnedEnemies.Clear();
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

        enemy.HitPlayer -= OnEnemyHitPlayer;
        enemy.HitPlayer += OnEnemyHitPlayer;

        enemy.Killed -= OnEnemyKilled;
        enemy.Killed += OnEnemyKilled;
    }

    private void OnEnemyDestroyed(EnemyController enemy)
    {
        if(spawnedEnemies.Contains(enemy))
            spawnedEnemies.Remove(enemy);
    }

    private void OnEnemyKilled(EnemyController enemy)
    {
        gameManager.EnemyKilled();
    }

    private void OnEnemyHitPlayer(EnemyController enemy)
    {
        gameManager.HitPlayer();
    }

    public List<EnemyController> GetEnemiesList() 
    {
        return spawnedEnemies;
    }
}
