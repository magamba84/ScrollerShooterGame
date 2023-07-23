using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float speed;
    private float damage;

    private float destroyBorder = 10f;
    public void Init(float speed, float damage)
    {
        this.speed = speed;
        this.damage = damage;
    }

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x) > destroyBorder || Mathf.Abs(transform.position.y) > destroyBorder)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var go = collision.gameObject;
        var enemy = go.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.Hit(damage);
            Destroy(gameObject);
        }

    }
}
