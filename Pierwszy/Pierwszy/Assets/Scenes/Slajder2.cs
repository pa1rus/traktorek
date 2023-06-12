using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slajder2 : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
    [SerializeField] private TMP_Text currentValue = null;

    [SerializeField] private List<string> yourValueList = new List<string> { "1", "2", "3", "4", "5", "6"};

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

    PlayerPrefs.SetInt("ilosc", (int)slider.value);
}
}
