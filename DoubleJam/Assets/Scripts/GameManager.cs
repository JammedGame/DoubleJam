using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; set; }

    public float timeLeft;

    [Range(0, 1)]
    public float duskDawnSlider;

    private bool completed = false;
    public SunRay[] sunRays;
    Image countdownTimer;

	public GameObject player;
	public Player playerScript;

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

		playerScript = player.GetComponent<Player>();
        if (EditorSceneManager.GetActiveScene().name != "MainMenu")
        {
            timeLeft = 20f;
            countdownTimer = GameObject.Find("CountdownTimer").GetComponent<Image>();
        }
    }

    void Update()
    {
        if (EditorSceneManager.GetActiveScene().name != "MainMenu")
        {
            Countdown();
        }
    }

    void Countdown()
    {
		if (!playerScript.inShadow) {
            timeLeft -= Time.deltaTime;
            countdownTimer.fillAmount = timeLeft / 20;
            CheckDeath();
        }
    }

    void CheckCompleted()
    {
        if (completed)
        {
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

    void CheckDeath()
    {
        if (completed)
        {
            return;
        }
        if (countdownTimer.fillAmount <= 0)
        {
			print("Dead");
			completed = true;
        }
    }

    void Completed()
    {
        completed = true;
        print("Complited!");
    }

    public void StartGame()
    {
        EditorSceneManager.LoadScene("L0");
    }
}
