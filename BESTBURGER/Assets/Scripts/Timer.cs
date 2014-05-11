using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public int clockTimer;
	float timer;
	public bool timerOn;
	void Start () {
	}
	

	void Update () {


		timer += Time.deltaTime;
		if (timer >= 2f && timerOn) {
			clockTimer--;
			timer = 0;
				}
		if (clockTimer <= 0)
						clockTimer = 0;
		guiText.text = clockTimer.ToString();

	}
}
