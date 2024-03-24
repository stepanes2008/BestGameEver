using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public TextMeshProUGUI levelValueTMP;
    public RectTransform _experienceValueRectTransform;

    private int _levelValue = 1;

    private float _experienceCurrentValue = 0f;
    private float _experienceTargetValue = 100f;
    
    void Start()
    {
        DrawUI();
    }

    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if (_experienceCurrentValue >= _experienceTargetValue)
        {
            _levelValue++;
            _experienceCurrentValue -= _experienceTargetValue;
        }
        DrawUI();
    }

    private void DrawUI()
    {
        _experienceValueRectTransform.anchorMax = new Vector3(_experienceCurrentValue / _experienceTargetValue, 1);
        levelValueTMP.text = _levelValue.ToString();
    }
}
