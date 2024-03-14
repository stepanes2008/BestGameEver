using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Update()
    {
        if (value <= 0)
        {
            DestroySelf();
        }
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
    public void DealDamage(float damage)
    {
        value -= damage;
        Debug.Log(value);
        if (value <= 0)
        {
            DestroySelf();
        }
        DrawHealthBar();
    }
    private void DestroySelf()
    {
        if (!DeathOn)
        {
            DeathOn = true;
            raptorEat.Play();
            audioSource.Play();
        }
        IsDead = true;
        _time += Time.deltaTime;
        //Raptor.GetComponent<Animator>().SetTrigger("Death");
        gameOverScreen.SetActive(true);
        gameplayUI.SetActive(false);
        Player.GetComponent<Animator>().SetTrigger("Death");
        Raptor.GetComponent<Animator>().SetTrigger("Loose");

        GetComponent<RotateByX>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        //Destroy(Player);
    }
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector3(value / _maxValue, 1);
    }
}
