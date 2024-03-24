using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public GameObject Player;
    public GameObject HexEffectPrefab;
    public GameObject Raptor;
    public float value = 100;
    public float _time = 0f;
    public 

    void Update()
    {
        if (value <= 0)
        {
            DestroyEnemy();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Special")
        {
            Instantiate(HexEffectPrefab, transform.position, Quaternion.identity);
            DealDamage(100f);
        }
    }
    public void DealDamage(float damage)
    {
        Player.GetComponent<PlayerProgress>().AddExperience(0.2f);
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
        if (_time >= 1f)
        {
            GetComponent<EnemyAI>().AddKill();
            Destroy(gameObject);
        }
    }
}
