using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kwadraciki : MonoBehaviour
{
	public bool czy_zyzne = false; //zmienna
	
	public Sprite op, nieop, dom;
	
	private SpriteRenderer sr;

	float delay = 1f;
	float timer = 0;

	bool isCounting = false;

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
		if(isCounting){
			timer += Time.deltaTime;
			if (timer > delay)
			{
				zamien();
			}
		}
    }
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (czy_zyzne)
			return;

		if(col.gameObject.tag == "1" || col.gameObject.tag == "2" || col.gameObject.tag == "3" || col.gameObject.tag == "4" || col.gameObject.tag == "5" || col.gameObject.tag == "6"){

			ParticleSystem x = col.gameObject.GetComponent<ParticleSystem>();

			x.Play();

			timer = 0;
			isCounting = true;
		}

	}
	

	void zamien()
	{
		sr.sprite = op;
		czy_zyzne = true;
		PlayerPrefs.SetInt("ile", PlayerPrefs.GetInt("ile")+1);
		isCounting = false;
	}
}
