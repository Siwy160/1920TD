using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Stats")]
    public float range = 8f;
    public float rotationSpeed = 360f;
    public float fireRate = 1f;
    public float damage = 1f;
    public float bulletSpeed = 10f;

    [Header("Unity stuff")]
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private Transform target;
    private float fireCountdown = 0f;

    public string enemyTag = "EnemyTag";

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject closestEnemy = null;
        float distanceToClosest = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < distanceToClosest)
            {
                distanceToClosest = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null && distanceToClosest <= range)
        {
            target = closestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        lookRotation.x = 0;
        lookRotation.z = 0;
        partToRotate.rotation = Quaternion.Slerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed);


        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {

        GameObject bulletObject = GameObject.Instantiate(bulletPrefab, firePoint.position, partToRotate.rotation);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.Damage = damage;
        bullet.Speed = bulletSpeed;
        bullet.Direction = target.position - transform.position;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
