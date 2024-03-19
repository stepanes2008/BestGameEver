using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerHealth : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource raptorEat;
    public RectTransform valueRectTransform;
    public GameObject Player;
    public GameObject Raptor;
    public float value = 100;
    public float _time = 0f;
    public float _maxValue;
    public GameObject RaptorAsset;
    public GameObject Camera;

    public bool IsDead = false;

    public GameObject HealEffect;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;
    private bool DeathOn = false;

    private void Start()
    {
        RenderSettings.ambientLight = Color.black;
        _maxValue = value;
    }


    public void AddHealth(float amount)
    {
        value += amount;
        if (value > 100f)
        {
            value = 100f;
        }
        HealEffect.GetComponent<ParticleSystem>().Play();
        DrawHealthBar();
    }
    public void DealDamage(float damage, GameObject enemy)
    {
        value -= damage;
        Debug.Log(value);
        if (value <= 0)
        {
            DestroySelf(enemy);
        }
        DrawHealthBar();
    }
    void DestroySelf(GameObject enemy)
    {
        gameOverScreen.SetActive(true);
        if (!DeathOn)
        {
            DeathOn = true;
            raptorEat.Play();
            audioSource.Play();
        }
        IsDead = true;
        _time += Time.deltaTime;
        //Raptor.GetComponent<Animator>().SetTrigger("Death");
        gameplayUI.SetActive(false);
        Player.GetComponent<Animator>().SetTrigger("Death");
        enemy.GetComponent<Collider>().enabled = false;
        //GetComponent<Rigidbody>().isKinematic = true;
        //GetComponent<Collider>().isTrigger = true;
        enemy.GetComponent<Collider>().isTrigger = true;
        enemy.GetComponent<Animator>().SetBool("Loose", true);
        //RaptorAsset.GetComponent<EnemyAI>().viewAngle = 0f;
        enemy.GetComponent<NavMeshAgent>().Stop();
        //enemy.GetComponent<EnemyAI>().enabled = false;

        Camera.GetComponent<RotateByX>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        //Invoke("EnemyPickNewPoint", 2);
        //Destroy(Player);
        void EnemyPickNewPoint()
        {
            raptorEat.Stop();
            enemy.GetComponent<EnemyAI>().PickNewPatrolPoint();
        }
    }    
   
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Smoke")
        {
            DealDamage(50f, Raptor);
        }
    }
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector3(value / _maxValue, 1);
    }
}
