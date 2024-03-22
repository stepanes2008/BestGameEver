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

    public Vector3 EnemyRotation;
    public Vector3 EnemyPosition;
    public bool IsDead = false;

    public GameObject HealEffect;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;
    private bool DeathOn = false;
    public GameObject enemy;

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
        if (value <= 0)
        {
            DestroySelf(enemy);
        }
        DrawHealthBar();
    }
    public void DestroySelf(GameObject enemy1)
    {
        enemy = enemy1;
        gameOverScreen.SetActive(true);
        if (!DeathOn)
        {
            EnemyRotation = enemy.transform.localEulerAngles;
            EnemyPosition = enemy.transform.position;
            DeathOn = true;
            raptorEat.Play();
            audioSource.Play();
        }
        IsDead = true;
        _time += Time.deltaTime;
        gameplayUI.SetActive(false);
        Player.GetComponent<Animator>().SetTrigger("Death");
        enemy.GetComponent<Animator>().SetBool("Loose", true);
        enemy.GetComponent<NavMeshAgent>().isStopped = true;
        GetComponent<UltimateHex>().enabled = false;

        Camera.GetComponent<RotateByX>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector3(value / _maxValue, 1);
    }
}
