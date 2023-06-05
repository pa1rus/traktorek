using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public bool ismenu = false;

    public void play(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("symulator-jesień");
        
    }

    public void wynik(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("wyniki");

    }

    public void wyjdz(){
        Application.Quit();

    }

    public void menu(){
       UnityEngine.SceneManagement.SceneManager.LoadScene("menu");

    }

    void Start(){
        if(ismenu) {
            PlayerPrefs.SetInt("ile", 2);
            PlayerPrefs.SetFloat("m", 2);
            PlayerPrefs.SetInt("szybkosc", 1);
        }
    }
}
