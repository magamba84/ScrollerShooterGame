using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private float hp;

    [SerializeField] private GameObject explosion;

    private Transform border;

    public event Action<EnemyController> Destroyed;
    public event Action<EnemyController> Killed;
    public event Action<EnemyController> HitPlayer;

    public void Init(Transform border) 
    {
        this.border = border;
        var settings = GameSettings.Instance;
        moveSpeed = Random.Range(settings.EnemyMovementSpeedRange.min, settings.EnemyMovementSpeedRange.max);
        hp = settings.EnemyHp;
    }

    private void Update()
    {
        var newPosition = transform.position;
        newPosition.y -= moveSpeed * Time.deltaTime;
        transform.position = newPosition;

        if (transform.position.y <= border.position.y)
        {
            HitPlayer?.Invoke(this);
            Die();
        }
    }

    public void Hit(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Killed?.Invoke(this);
            Die();
        }
            
    }

    private void Die()
    { 
        var exp = Instantiate(explosion,transform.parent);
        exp.transform.position = transform.position;

        Destroyed?.Invoke(this);

        Destroy(gameObject);
    }
}
