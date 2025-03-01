using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CastGrenade : MonoBehaviour
{
    public float stunTime = 5f;
    private float timer = 0f;
    public float cooldown;
    public GameObject Grenade;
    public GameObject Player;

    public GameObject AbilityIcon;
    public Image SpellIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        UpdateUltimateIcon();
        if (Input.GetMouseButtonDown(1) && timer >= cooldown)
        {
            timer = 0f;
            Player.GetComponent<Animator>().SetTrigger("ThrowGrenade");
            Invoke("Cast", 0.5f);
        }
    }

    void Cast()
    {
        var grenade = Instantiate(Grenade, transform.position, transform.rotation);
        grenade.GetComponent<Rigidbody>().AddForce(transform.forward * 400f);
        grenade.GetComponent<Grenade>().stunTime = stunTime;
    }

    void UpdateUltimateIcon()
    {
        //находим текущий процент времени перезарядки (значение от 0 до 1)
        float fillAmount = timer / cooldown;
        //Параметр SpellIcon.fillAmount отвечает за заполнение иконки способности
        SpellIcon.fillAmount = fillAmount;
    }
}
