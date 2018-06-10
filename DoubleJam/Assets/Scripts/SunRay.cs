using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRay : MonoBehaviour {
	
	LineRenderer lr;
	
	public Transform target;
	public bool active = false;

	void Start()
	{
		lr = GetComponent<LineRenderer>();
		lr.startWidth = .5f;
		lr.endWidth = .1f;
		lr.enabled = false;
	}
	void Update () 
	{
		lr.SetPosition(0, transform.position);
        lr.SetPosition(1, new Vector3(target.transform.position.x - 0.5f, target.transform.position.y, target.transform.position.z));
	}

	public void Trigger() {
		active = true;
		lr.enabled = true;
	}
}
