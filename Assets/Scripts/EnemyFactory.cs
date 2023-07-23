using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject EnemyInstance;

    public GameObject CreateEnemy()
    {
        return Instantiate(EnemyInstance);
    }
}
