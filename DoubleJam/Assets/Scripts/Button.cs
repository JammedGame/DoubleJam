using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
	
	public GameObject obstacleToMove, placeToMoveTo;

	public float speed;

	[HideInInspector]
	public bool canMove;
	
	bool isLever, isInRange;

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "PressureBox")
		{
			canMove = true;
		}

		if(col.gameObject.tag == "Player")
		{
			isInRange = true;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.tag == "PressureBox")
		{
			GetComponent<Animator>().SetTrigger("Released");
			canMove = false;
		}

		if(col.gameObject.tag == "Player")
		{
			isInRange = false;
		}
	}

	void Update()
	{
		Pressure();
	}

	void MoveObstacle()
	{
		obstacleToMove.transform.position = Vector2.MoveTowards(obstacleToMove.transform.position, placeToMoveTo.transform.position, speed * Time.deltaTime);
	}

	void Pressure()
	{
		if(isLever == false)
		{
			if(canMove)
			{
				MoveObstacle();
			}
		}
	}
}
