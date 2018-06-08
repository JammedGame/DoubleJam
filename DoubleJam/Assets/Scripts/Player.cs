using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private int jumpAmount, jumpMax;

    public float speed, jumpForce, glideTimeLeft;

	Rigidbody2D rb;

	void Start()
	{
		glideTimeLeft = 1;
		jumpMax = 2;
		rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update () {
		Movement();
	}

	void Movement()
	{
		Jump();

		// Foward
		if(Input.GetKey(KeyCode.D)){
			transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
		}

		// Back
		if(Input.GetKey(KeyCode.A))
		{
			transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
		}
	}

	void Jump()
	{
		glideTimeLeft -= Time.deltaTime;
		if(glideTimeLeft < 0)
		{
			glideTimeLeft = 1;
			jumpAmount--;
			if(jumpAmount <= 0)
			{
				jumpAmount = 0;
			}
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
			jumpAmount++;
			rb.AddForce(transform.up * jumpForce);
		}

		// Jump counter
		if(jumpAmount == jumpMax)
		{
			jumpAmount = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.CompareTag("Ground")){
				print("hi");
		}
	}
}
