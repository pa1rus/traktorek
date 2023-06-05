using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class koniec : MonoBehaviour
{

    public TMP_Text dlugosc, ilosc, m, powierzcznia;

    int a, b;

    void Start()
    {
        //Pobranie wartosci i wypisanie wynikow


        if(PlayerPrefs.GetInt("dlugosc") == 0) a = 6;
        else if(PlayerPrefs.GetInt("dlugosc") == 1) a = 9;
        else if(PlayerPrefs.GetInt("dlugosc") == 2) a = 15;
        else if(PlayerPrefs.GetInt("dlugosc") == 3) a = 21;
        else if(PlayerPrefs.GetInt("dlugosc") == 4) a = 24;
        else if(PlayerPrefs.GetInt("dlugosc") == 5) a = 27;

        dlugosc.text = "Dlugosc lancy: "+a.ToString()+"m";

        ilosc.text = "Ilosc sekcji: "+(PlayerPrefs.GetInt("ilosc")+1).ToString();

        m.text = "Przejechana  odległosć: "+PlayerPrefs.GetFloat("m").ToString()+"m";

        b = PlayerPrefs.GetInt("ile")*9;

        powierzcznia.text = "Nawieziona powierzchnia: "+b+"m2";
    }

}
