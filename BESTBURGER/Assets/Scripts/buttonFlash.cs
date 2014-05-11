using UnityEngine;
using System.Collections;

public class buttonFlash : MonoBehaviour {
	public bool lettuce,cheese,bacon,patty,tomato;
	float timer;
	bool startTimer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (startTimer) {
			timer += Time.deltaTime;
			if(timer > .1f){
				this.renderer.enabled = false;
				timer = 0;
				startTimer = false;
				}
		}



		if (Input.GetButtonDown ("Lettuce") && lettuce) {
				this.renderer.enabled = true;
				startTimer = true;
				}

		if (Input.GetButtonDown ("Grilled") && patty) {
			this.renderer.enabled = true;
			startTimer = true;
			}

		if (Input.GetButtonDown ("Cheese") && cheese) {
			this.renderer.enabled = true;
			startTimer = true;
			}

		if (Input.GetButtonDown ("Tomato") && tomato) {
			this.renderer.enabled = true;
			startTimer = true;
		}

		if (Input.GetButtonDown ("Bacon") && bacon) {
			this.renderer.enabled = true;
			startTimer = true;
		}

	}
}
