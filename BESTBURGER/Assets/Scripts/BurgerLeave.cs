using UnityEngine;
using System.Collections;

public class BurgerLeave : MonoBehaviour {
	public float waitToLeave,stopMoving;
	float timer;
	bool trig = false, moved = false;
	public BurgerCheck bc;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

				if (bc.maxSize > bc.currentBurger) {
			moved = false;
			trig = false;
			timer = 0;
				}
		if (bc.maxSize <= bc.currentBurger && bc.mistakes < 2)
						trig = true;

		if(trig && !moved){
			timer += Time.deltaTime;
			if(timer >= waitToLeave )
			transform.Translate (Vector3.left * (10*Time.deltaTime));
			if(timer >= stopMoving ){
				timer = 0;
				trig = false;
				moved = true;
			}
		}
	}
}
