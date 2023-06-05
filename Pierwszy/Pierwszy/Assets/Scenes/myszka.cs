using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class szczur : MonoBehaviour
{

    float x;
	Vector3 savedMousePos, savedCameraPos;
	
	public Camera cam;
	
	public float mouseMultiplier;
	
	void Setup()
	{
	}

    void FixedUpdate()
    {
        x = Input.mouseScrollDelta.y;
		Vector3 mousePos = Input.mousePosition;
		
		cam.orthographicSize -= x;
		
		if (cam.orthographicSize < 1)
			cam.orthographicSize = 1;
		
		if (Input.GetMouseButtonDown(0)) {
			savedMousePos = mousePos;
			savedCameraPos = cam.transform.position;
		}
		
		if (Input.GetMouseButton(0)) {
			cam.transform.position = savedCameraPos + (savedMousePos - mousePos) * mouseMultiplier;
			savedMousePos = mousePos;
			savedCameraPos = cam.transform.position;
		}

    }
}
