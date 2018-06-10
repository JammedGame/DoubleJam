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

	private bool completed = false;
	public SunRay[] sunRays;
	Image countdownTimer;

	void Start()
	{
		timeLeft = 20f;
		countdownTimer = GameObject.Find("CountdownTimer").GetComponent<Image>();
        sunRays = GameObject.FindObjectsOfType<SunRay>();

		var sun = GameObject.Find("Sun");
		foreach (var sunRay in sunRays)
		{
			sunRay.target = sun.transform;
		}

    }

	void Update()
	{
		
		Countdown();
	}

	void Countdown()
	{
		timeLeft -= Time.deltaTime;
		countdownTimer.fillAmount = timeLeft / 20;
		CheckCompleted();
	}

	void CheckCompleted() {
		if (completed) {
			return;
		}
		int active = 0;
        foreach (var sunRay in sunRays)
        {
            if (sunRay.active)
            {
                active += 1;
            }
        }
        if (active == sunRays.Length)
        {
			Completed();
        }
	}

	void Completed() {
		completed = true;
		print("Complited!");
	}
}
