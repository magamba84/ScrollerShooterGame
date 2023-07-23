using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private PlayerMoveController playerMoveController;
    [SerializeField] private UIController uiController;

    private int playerHp;
    private int scoreToWin;

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        var settings = GameSettings.Instance;
        playerHp = settings.PlayerStartHp;
        scoreToWin = Random.Range(settings.EnemyCountRange.min, settings.EnemyCountRange.max);
        enemyManager.StartSpawn();
        playerMoveController.SetActive(true);
        uiController.ShowHP(playerHp);
    }

    private void EndGame(bool win)
    {
        enemyManager.StopSpawn();
        playerMoveController.SetActive(false);
        uiController.ShowEndGame(win);
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
        uiController.ShowHP(playerHp);
        if (playerHp <= 0)
            EndGame(false);
    }

}
