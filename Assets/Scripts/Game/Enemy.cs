using System;
using UnityEngine;

public class Enemy : HittableObject
{
    [Header("Audio")]
    [SerializeField] private AudioSource movementSound;
    [SerializeField] private AudioSource deathSound;

    [Header("Stats")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private float health = 10;

    private Transform target;
    private int waypointIndex;
    private float rotationSpeed = 10f;
    [SerializeField] private Animator animator;
    private bool alive = true;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        SetNewTarget();
    }

    void Update()
    {
        if (health <= 0)
        {
            return;
        }
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            SetNewTarget();
        }
    }

    internal bool IsAlive()
    {
        return health > 0;
    }

    private void SetNewTarget()
    {
        if (waypointIndex >= Waypoints.waypoints.Length)
        {
            Destroy(gameObject);
            return;
        }
        target = Waypoints.waypoints[waypointIndex];
        waypointIndex++;
    }

    override internal void OnHit(float damage)
    {
        base.OnHit(damage);
        health -= damage;
        Debug.Log("Damage recieved. HP: " + health);
        if (alive && health <= 0)
        {
            Debug.Log("Enemy died");
            alive = false;
            animator.SetTrigger("Death");
            deathSound.Play();
            Destroy(gameObject, 2f);
        }
    }
}
