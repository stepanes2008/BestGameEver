using UnityEngine;
using UnityEngine.UI;

public class UltimateHex : MonoBehaviour
{
    //Ссылка на префаб утки
    public GameObject collider;
    //Ссылка на иконку способности
    public Image SpellIcon;
    //Время перезарядки
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
        Instantiate(collider, transform.position, transform.rotation);
        _timer = 0f;
    }

    void UpdateUltimateIcon()
    {
        //находим текущий процент времени перезарядки (значение от 0 до 1)
        float fillAmount = _timer / Cooldown;
        //Параметр SpellIcon.fillAmount отвечает за заполнение иконки способности
        SpellIcon.fillAmount = fillAmount;
    }
}
