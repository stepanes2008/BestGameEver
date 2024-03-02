using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;

    public void DealDamage(float damage)
    {
        value -= damage;
        Debug.Log(value);
        if (value <= 0)
        {
            DestroyEnemy();
        }
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
