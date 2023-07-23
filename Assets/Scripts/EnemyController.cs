using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private float hp;

    [SerializeField] private GameObject explosion;

    [SerializeField] private Transform border;

    private void Start() 
    { 
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
            Die();
        }
    }

    public void Hit(float damage)
    {
        hp -= damage;
        if (hp <= 0)
            Die();
    }

    private void Die()
    { 
        var exp = Instantiate(explosion,transform.parent);
        exp.transform.position = transform.position;
        Destroy(gameObject);
    }
}
