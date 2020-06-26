using System;
using System.Collections;
using GamePlay;
using UnityEngine;

public class Enemy : HittableObject
{
    [SerializeField] private Sound[] movementSounds;
    [SerializeField] private Sound[] deathSounds;

    [Header("Animation")]
    [SerializeField] private float movementAnimationMultiplier = 1;
    [SerializeField] private float deathAnimationMultiplier = 1;

    [Header("Stats")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private float health = 10;
    [SerializeField] private int _money = 100;

    private Transform target;
    private int waypointIndex;
    private float rotationSpeed = 10f;
    [SerializeField] private Animator animator;
    private bool alive = true;
    private IEnumerator movementCoroutine;

    private EnemyDeathListener _listener;

    public EnemyDeathListener Listener { set => _listener = value; }

    void Start()
    {
        base.Start();
        animator = GetComponentInChildren<Animator>();
        animator.SetFloat("RunAnimationMultiplier", movementAnimationMultiplier);
        animator.SetFloat("DeathAnimationMultiplier", deathAnimationMultiplier);
        movementCoroutine = PlayRandomSoundRepeately(movementSounds);
        StartCoroutine(movementCoroutine);
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
            _listener.OnEnemyDead(_money);
            alive = false;
            animator.SetTrigger("Death");
            PlayRandomSound(deathSounds);
            StopCoroutine(movementCoroutine);
            movementAudioSource.Stop();
            Destroy(gameObject, 2f);
        }
    }
}
