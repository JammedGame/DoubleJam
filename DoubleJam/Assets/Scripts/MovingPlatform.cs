using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public bool needsButton;

	public PressurePlate buttonThatEnables;

	public GameObject platform;
	
	private Transform nextPos;	
	public Transform posA, posB;

	public float speed;

	void Start()
	{
		platform.transform.position = posA.transform.position;

        nextPos = posB;
	}

	// Update is called once per frame
	void Update () {

		Debug.DrawLine(platform.transform.position, nextPos.position, Color.red, .1f);

		if(needsButton == false)
		{
			Movement();
		}

		if(needsButton == true)
		{
			if(buttonThatEnables.canMove == true)
			{
				Movement();
			}
		}
	}

	void Movement()
	{
		ChangeTargetPosition();

        platform.transform.position = Vector3.MoveTowards(platform.transform.position, nextPos.transform.position, speed * Time.deltaTime);
	}

	void ChangeTargetPosition()
    {
        if(Vector3.Distance(platform.transform.position, nextPos.transform.position) <= 0.1)
        {
            if(nextPos == posB)
            {
                nextPos = posA;
            }
            else if (nextPos == posA)
            {
                nextPos = posB;
            }
        }
    }
}
