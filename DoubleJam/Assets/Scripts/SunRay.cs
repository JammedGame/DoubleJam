using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRay : MonoBehaviour {
	
	LineRenderer lr;
	
	public Transform target;

	void Start()
	{
		lr = GetComponent<LineRenderer>();
		lr.startWidth = .1f;
		lr.endWidth = .5f;
	}
	void Update () 
	{
		lr.SetPosition(0, transform.position);
        lr.SetPosition(1, target.transform.position);
	}
}
