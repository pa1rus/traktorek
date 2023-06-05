using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lokalizator : MonoBehaviour
{
	public gps Gps0;
	public gps Gps1;
	public gps Gps3;
	
	struct gps_coord { public double n, e; }
	
	gps_coord NE0, NE3, G;
	
	public TMP_Text wspolrzedneX, wspolrzedneY;
	
	float x0, y0, x1, y1, x3, y3;
	
	float m, n, o, a, b, theta, g, xr, yr, f, e;
	
	void Start()
	{
		NE0.n = Gps0.NorthCoord;
		NE0.e = Gps0.EastCoord;
		NE3.n = Gps3.NorthCoord;
		NE3.e = Gps3.EastCoord;
		
		x0 = Gps0.transform.position.x;
		y0 = Gps0.transform.position.y;
		x1 = Gps1.transform.position.x;
		y1 = Gps1.transform.position.y;
		x3 = Gps3.transform.position.x;
		y3 = Gps3.transform.position.y;
		
		n = hypot(x1 - x0, y1 - y0);
		o = hypot(x3 - x1, y3 - y1);
		
		a = (x1 - x0)/n;
	}
	
	void Update()
	{
		float x2 = transform.position.x;
		float y2 = transform.position.y;
		
		m = hypot(x2 - x0, y2 - y0);
		b = (x2 - x0)/m;
		theta = Mathf.Asin(b) - Mathf.Asin(a);
		g = m/n * Mathf.Cos(theta);
		
		xr = x0 + g * (x1 - x0);
		yr = y0 + g * (y1 - y0);
		
		e = hypot(xr - x0, yr - y0);
		f = hypot(xr - x2, yr - y2);
		
		if (x2 < xr) f *= -1;
		
		G.n = NE0.n + (e * (NE3.n - NE0.n)) / n;
		G.e = NE0.e + (f * (NE3.e - NE0.e)) / o;
		
		wspolrzedneX.text = G.e.ToString();
		wspolrzedneY.text = G.n.ToString();
	}
	
	float hypot(float a, float b)
	{
		return Mathf.Sqrt(a*a+b*b);
	}
}
