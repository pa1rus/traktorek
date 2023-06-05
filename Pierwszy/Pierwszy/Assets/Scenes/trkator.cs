using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class trkator : MonoBehaviour
{
	
	public GameObject[] punkty; 

    public float speed; //szybkosc
    public float offset; //korekcja kąta

    private float angle; // obecny kąt do celu
    private Vector3 moveOffset;

    Vector3 Cel;

    //int target = 0;

    public GameObject[] opryskiwacze;

    public GameObject[] m6, m9, m15, m21, m24, m27;

    private bool canMove;

    float dystans = 0;

    void Start(){

        Cel = transform.position;

        opryskiwacze[PlayerPrefs.GetInt("dlugosc")].SetActive(true);


        if(PlayerPrefs.GetInt("dlugosc") == 0) m6[PlayerPrefs.GetInt("ilosc")].SetActive(true);
        else if(PlayerPrefs.GetInt("dlugosc") == 1) m9[PlayerPrefs.GetInt("ilosc")].SetActive(true);
        else if(PlayerPrefs.GetInt("dlugosc") == 2) m15[PlayerPrefs.GetInt("ilosc")].SetActive(true);
        else if(PlayerPrefs.GetInt("dlugosc") == 3) m21[PlayerPrefs.GetInt("ilosc")].SetActive(true);
        else if(PlayerPrefs.GetInt("dlugosc") == 4) m24[PlayerPrefs.GetInt("ilosc")].SetActive(true);
        else if(PlayerPrefs.GetInt("dlugosc") == 5) m27[PlayerPrefs.GetInt("ilosc")].SetActive(true);

        if(PlayerPrefs.GetInt("szybkosc") == 0) speed = 0.5f;
        else if(PlayerPrefs.GetInt("szybkosc") == 1) speed = 1;
        else if(PlayerPrefs.GetInt("szybkosc") == 2) speed = 1.5f;
        else if(PlayerPrefs.GetInt("szybkosc") == 3) speed = 2f;
        else if(PlayerPrefs.GetInt("szybkosc") == 4) speed = 2.5f;
        

    }

    void Update()
    {
        /*
        
        if (target >= punkty.Length - 1) return; // ograniczenie zmiennej target do dlugosci tabl. punkty
        if (transform.position == punkty[target].transform.position) target++; // przejscie do kolejnego punktu
		
		Vector3 targetPos = punkty[target].transform.position;
		
		// przesuniecie w kierunku celu
		transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
		
		// obliczenie pozostalego dystansu do celu
		moveOffset = targetPos - transform.position;
		// obrot w kierunku celu
		angle = Mathf.Atan2(moveOffset.y, moveOffset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));

        */

        if(Input.GetMouseButtonUp(0) && canMove){

            canMove = false;
            Cel = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Cel.z = transform.position.z;

            dystans += Vector2.Distance(transform.position, Cel) * 17.65f;

            PlayerPrefs.SetFloat("m", dystans);

        }

        transform.position = Vector3.MoveTowards(transform.position, Cel, speed * Time.deltaTime);

        // obliczenie pozostalego dystansu do celu
		moveOffset = Cel - transform.position;
		// obrot w kierunku celu

		angle = Mathf.Atan2(moveOffset.y, moveOffset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));

        if(transform.position == Cel) canMove = true;

        Debug.Log(dystans);
        
		
		/*wspolrzedneX.text = stX.ToString()+"."+mX.ToString()+"'"+sX.ToString()+'"'+"N";
		wspolrzedneY.text = stY.ToString()+"."+mY.ToString()+"'"+sY.ToString()+'"'+"E";*/
    }

}