using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {
	
	public GameObject obstacleToMove, placeToMoveTo;

	public float speed;

	[HideInInspector]
	public bool canMove;

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "PressureBox")
		{
			canMove = true;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.tag == "PressureBox")
		{
			canMove = false;
		}
	}

	void Update()
	{
		if(canMove)
		{
			MoveObstacle();
		}
	}

	void MoveObstacle()
	{
		obstacleToMove.transform.position = Vector2.MoveTowards(obstacleToMove.transform.position, placeToMoveTo.transform.position, speed * Time.deltaTime);
	}
}
