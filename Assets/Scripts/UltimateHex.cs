using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UltimateHex : MonoBehaviour
{
    //Ссылка на префаб утки
    public GameObject collider;
    //Ссылка на иконку способности
    public Image SpellIcon;
    //Время перезарядки
    public float Cooldown;
    private int UseCount = 3;
    public GameObject Icon;
    public GameObject CounterText;

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
        if (UseCount > 0)
        {
            Instantiate(collider, transform.position, transform.rotation);
            _timer = 0f;
            UseCount--;
            CounterText.GetComponent<TMP_Text>().text = UseCount.ToString();
        }
        if (UseCount == 0)
        {
            Destroy(Icon);
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
