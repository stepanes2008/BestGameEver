using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UltimateHex : MonoBehaviour
{
    public TextMeshProUGUI UsagesLeftTMP;
    public GameObject AbilityIcon;
    public int UseagesLeft = 3;
    public GameObject collider;
    public Image SpellIcon;
    public float Cooldown;

    float _timer = 0f;

    void Update()
    {
        //Обновляем таймер и иконку
        _timer += Time.deltaTime;
        UpdateUltimateIcon();

        //Если нажата клавиша способности и таймер больше времени перезарядки
        if (Input.GetKeyDown(KeyCode.Space) && _timer >= Cooldown)
        {
            CastHex();
        }
    }

    void CastHex()
    {
        /*
        //Находим всех врагов
        EnemyHealth[] enemies = FindObjectsOfType <???> ();
        //Проходим по всем врагам
        foreach (EnemyHealth enemy in enemies)
        {
            //Уничтожаем врага, создаем на месте врага эффект превращения и утку
            Destroy(enemy);
            Instantiate(HexEffectPrefab, enemy.transform.position, Quaternion.identity);
            Instantiate(Duck, enemy.transform.position, enemy.transform.rotation);
        }
        //Сбрасываем таймер
        */
        if (UseagesLeft > 0)
        {
            UseagesLeft--;
            UsagesLeftTMP.text = UseagesLeft.ToString();
            Instantiate(collider, transform.position, transform.rotation);
            _timer = 0f;
        }
        if (UseagesLeft <= 0)
        {
            Destroy(AbilityIcon);
            enabled = false;
        }

    }

    void UpdateUltimateIcon()
    {
        //находим текущий процент времени перезарядки (значение от 0 до 1)
        float fillAmount = _timer / Cooldown;
        //Параметр SpellIcon.fillAmount отвечает за заполнение иконки способности
        SpellIcon.fillAmount = fillAmount;
    }
}
