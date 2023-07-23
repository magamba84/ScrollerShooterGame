using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private int playerStartHp;
    public int PlayerStartHp 
    {
        get
        {
            return playerStartHp;
        }
    }

    [SerializeField] private IntRange enemyCountRange;
    public IntRange EnemyCountRange
    { 
        get 
        { 
            return enemyCountRange; 
        } 
    }

    [SerializeField] private FloatRange enemySpawnTimeoutRange;
    public FloatRange EnemySpawnTimeoutRange
    {
        get
        {
            return enemySpawnTimeoutRange;
        }
    }

    [SerializeField] private FloatRange enemyMovementSpeedRange;
    public FloatRange EnemyMovementSpeedRange
    {
        get
        {
            return enemyMovementSpeedRange;
        }
    }

    [SerializeField] private int enemyHp;
    public int EnemyHp
    {
        get
        {
            return enemyHp;
        }
    }

    [SerializeField] private float playerAttackRadius;
    public float PlayerAttackRadius
    {
        get 
        { 
            return playerAttackRadius;
        }
    }

    [SerializeField] private float playerAttackTimeout;
    public float PlayerAttackTimeout
    {
        get
        {
            return playerAttackTimeout;
        }
    }

    [SerializeField] private int playerDamage;
    public int PlayerDamage
    {
        get
        {
            return playerDamage;
        }
    }

    [SerializeField] private float bulletSpeed;
    public float BuletSpeed
    {
        get
        {
            return bulletSpeed;
        }
    }

    private static GameSettings _instance;
    public static GameSettings Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}
