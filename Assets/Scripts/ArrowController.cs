using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float speed;
    public GameObject Arrow;
    public float damage = 25;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyArrow", 10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            DestroyArrow();
            DamageEnemy(collision);
        }
    }
    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }
    private void DestroyEnemy(Collision enemy)
    {
        Destroy(enemy.gameObject);
    }
    private void DestroyArrow()
    {
        Destroy(gameObject);
    }
    private void MoveFixedUpdate()
    {
        transform.position += transform.up * speed * Time.fixedDeltaTime;
    }
}
