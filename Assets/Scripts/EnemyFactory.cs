using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject EnemyInstance;
    [SerializeField] private Transform SpawnParent;

    public GameObject CreateEnemy()
    {
        return Instantiate(EnemyInstance, SpawnParent);
    }
}
