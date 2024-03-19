using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StunEnemy : MonoBehaviour
{
    public GameObject GrenadeEffect;
    public GameObject Raptor;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Smoke")
        {
            GetComponent<EnemyAI>().enabled = false;
            GetComponent<NavMeshAgent>().isStopped = true;
            gameObject.GetComponent<Animator>().SetBool("Stun", true);
            Invoke("NullifyEffect", 7);
            Debug.Log("+");
        }
    }
    void NullifyEffect()
    {
        gameObject.GetComponent<Animator>().SetBool("Stun", false);
        GetComponent<EnemyAI>().enabled = true;
        GetComponent<NavMeshAgent>().isStopped = false;
        GetComponent<EnemyAI>().PickNewPatrolPoint();
    }
}
