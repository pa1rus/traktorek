using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kat : MonoBehaviour
{
    public Transform punkt;
    void Start()
    {
        Vector3 target = punkt.position - transform.position;
		float angle = Vector3.Angle(target, transform.right);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
