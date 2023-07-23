using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private GameObject bulletInstance;
    [SerializeField] private Transform bulletSpawnPoint;
    public List<Transform> enemies;
    private float attackRadius;
    private float attackTimeout;
    private float bulletSpeed;
    private float damage;
    private float findAimsInterval = 0.05f;

    private void Start()
    {
        var settings = GameSettings.Instance;
        attackTimeout = settings.PlayerAttackTimeout;
        attackRadius = settings.PlayerAttackRadius;
        bulletSpeed = settings.BuletSpeed;
        damage = settings.PlayerDamage;
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        do
        {
            var aim = FindAim();
            if (aim == null)
            {
                yield return new WaitForSeconds(findAimsInterval);
            }
            else
            {
                Attack(aim);
                yield return new WaitForSeconds(attackTimeout);
            }
        } while (true);
    }

    private void Attack(Transform aim)
    {
        var bullet = Instantiate(bulletInstance, transform.parent);
        bullet.transform.position = bulletSpawnPoint.position;
        var direction = (aim.position - bulletSpawnPoint.position).normalized;
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0,0, rotationZ);
        bullet.GetComponent<BulletController>().Init(bulletSpeed, damage);
    }

    private Transform FindAim()
    {
        if (enemies.Count == 0)
            return null;

        Transform closest = null;
        float minRange = float.MaxValue;
        foreach (var e in enemies)
        {
            var range = (e.position - transform.position).magnitude;
            if (range <= attackRadius && range < minRange)
            {
                minRange = range;
                closest = e;
            }
        }
        return closest;
    }
}
