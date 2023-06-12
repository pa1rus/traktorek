using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slajder : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
    [SerializeField] private TMP_Text currentValue = null;

    [SerializeField] private List<string> yourValueList = new List<string> { "6m", "9m", "15m", "21m", "24m", "27m"};

private void Start()
{
    slider.onValueChanged.AddListener(delegate { SliderValueChangedCallback(); });

    slider.minValue = 0;
    slider.maxValue = yourValueList.Count - 1;
    slider.wholeNumbers = true;
}

/// <summary>
/// </summary>

private void SliderValueChangedCallback()
{
    int numericSliderValue = (int)slider.value;
    
    currentValue.text = yourValueList[numericSliderValue];

    PlayerPrefs.SetInt("dlugosc", (int)slider.value);
}
}
