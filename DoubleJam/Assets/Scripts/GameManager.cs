using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public static GameManager Instance {get;set;}

	public float timeLeft;

	[Range(0, 1)]
	public float duskDawnSlider;

	public GameObject background;

	Image countdownTimer;

	void Start()
	{
		print(Screen.height - background.GetComponent<SpriteRenderer>().sprite.rect.height);
		timeLeft = 20f;
		countdownTimer = GameObject.Find("CountdownTimer").GetComponent<Image>();
	}

	void Update()
	{
		Countdown();
		BackgroundMove();
	}

	void Countdown()
	{
		// timeLeft -= Time.deltaTime;
		// countdownTimer.fillAmount = timeLeft / 20;
	}

	void BackgroundMove()
	{
		// background.transform.position = new Vector2(background.transform.position.x, Mathf.Lerp(Screen.height - background.GetComponent<SpriteRenderer>().sprite.rect.height, 0, duskDawnSlider));
	}
}
