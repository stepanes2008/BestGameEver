using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject Raptor;
    public float value = 100;
    public float _time = 0f;

    void Update()
    {
        if (value <= 0)
        {
            DestroyEnemy();
        }
    }

    public void DealDamage(float damage)
    {
        GetComponent<Animator>().SetTrigger("GetHit");
        value -= damage;
        Debug.Log(value);
        if (value <= 0)
        {
            DestroyEnemy();
        }
    }
    private void DestroyEnemy()
    {
        _time += Time.deltaTime;
        GetComponent<Animator>().SetTrigger("Death");
        if (_time >= 1.5f)
        {
            Destroy(gameObject);
        }
    }
}
