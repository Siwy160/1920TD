using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed;

    private Transform target;
    private int waypointIndex;

    public EnemyData enemyData;

    void Start()
    {
        speed = enemyData.speed;
        SetNewTarget();
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            SetNewTarget();
        }
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
}
