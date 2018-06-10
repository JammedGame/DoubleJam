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
		timeLeft = 20f;
		countdownTimer = GameObject.Find("CountdownTimer").GetComponent<Image>();
	}

	void Update()
	{
		Countdown();
	}

	void Countdown()
	{
		timeLeft -= Time.deltaTime;
		countdownTimer.fillAmount = timeLeft / 20;
	}
}
