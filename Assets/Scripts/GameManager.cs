using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] PlayerMoveController playerMoveController;

    private int playerHp;
    private int scoreToWin;

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        var settings = GameSettings.Instance;
        playerHp = settings.PlayerStartHp;
        scoreToWin = Random.Range(settings.EnemyCountRange.min, settings.EnemyCountRange.max);
        enemyManager.StartSpawn();
        playerMoveController.SetActive(true);
    }

    private void EndGame(bool win)
    {
        enemyManager.StopSpawn();
        playerMoveController.SetActive(false);
    }

    public void EnemyKilled()
    {
        scoreToWin--;
        if (scoreToWin <= 0)
            EndGame(true);
    }

    public void HitPlayer()
    {
        playerHp--;
        if (playerHp <= 0)
            EndGame(false);
    }

   
    
}
