using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class CameraMovement : MonoBehaviour {

	public GameObject player;
	public float cameraSpeed;
	public float cameraOffset;

	void Start()
	{
		if(EditorSceneManager.GetActiveScene().name != "MainMenu")
		{
			cameraOffset = 0;
		}
	}

	void LateUpdate () {
		transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + cameraOffset, Mathf.Clamp(player.transform.position.y, -1, player.transform.position.y), transform.position.z),cameraSpeed * Time.deltaTime);
	}
}
