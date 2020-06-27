using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage { get; set; }
    public float Speed { get; set; }
    public string EnemyTag { get; set; }
    private Vector3 previousPosition;
    public GameObject particleEffect;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
        RaycastHit[] hits = Physics.RaycastAll(new Ray(previousPosition, (transform.position - previousPosition).normalized), (transform.position - previousPosition).magnitude);
        if (hits.Length > 0)
        {
            OnObjectHit(hits[0].collider.gameObject);
        }
        previousPosition = transform.position;
    }

    void OnObjectHit(GameObject target)
    {
        if (target.tag == EnemyTag)
        {
            GameObject particle = Instantiate(particleEffect, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(particle, 2f);
            Destroy(gameObject);
            target.GetComponent<Enemy>().OnHit(Damage);
        }
    }
}
