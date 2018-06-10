using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Spikes : MonoBehaviour {

	public float delayBeforeRestart;

	void Start()
	{
		delayBeforeRestart = 5;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Spikes")
		{
			// Kill
		}
	}

	IEnumerator StartAgain()
	{
		yield return new WaitForSeconds(delayBeforeRestart);
		EditorSceneManager.LoadScene("MainMenu");
	}
}
