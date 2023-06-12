using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slajdr3 : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
    [SerializeField] private TMP_Text currentValue = null;

    [SerializeField] private List<string> yourValueList = new List<string> {"5kmh", "10kmh", "15kmh", "20kmh", "25kmh", "30kmh"};

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

    PlayerPrefs.SetInt("szybkosc", (int)slider.value);
}
}
