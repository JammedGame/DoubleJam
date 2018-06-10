using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject player;
	public float cameraSpeed;

	void LateUpdate () {
		transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, Mathf.Clamp(player.transform.position.y, -1, player.transform.position.y), transform.position.z),cameraSpeed * Time.deltaTime);
	}
}
