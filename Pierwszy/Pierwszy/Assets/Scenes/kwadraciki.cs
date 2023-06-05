using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kwadraciki : MonoBehaviour
{
	public bool czy_zyzne = false; //zmienna
	
	public Sprite op, nieop, dom;
	
	private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
		
		if (czy_zyzne)
			sr.sprite = dom;
		else
			sr.sprite = nieop;
    }

    // Update is called once per frame
    void Update()
    {
    }
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (czy_zyzne)
			return;

		if(col.gameObject.tag == "1" || col.gameObject.tag == "2" || col.gameObject.tag == "3" || col.gameObject.tag == "4" || col.gameObject.tag == "5" || col.gameObject.tag == "6"){

			ParticleSystem x = col.gameObject.GetComponent<ParticleSystem>();

			x.Play();
		}

	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		
		if ((col.gameObject.tag == "1" || col.gameObject.tag == "2" || col.gameObject.tag == "3" || col.gameObject.tag == "4" || col.gameObject.tag == "5" || col.gameObject.tag == "6") && !czy_zyzne)
		{
			sr.sprite = op;
			czy_zyzne = true;
			PlayerPrefs.SetInt("ile", PlayerPrefs.GetInt("ile")+1);
		}
	}
}
