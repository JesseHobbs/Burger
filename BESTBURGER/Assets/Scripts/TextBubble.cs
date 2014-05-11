using UnityEngine;
using System.Collections;

public class TextBubble : MonoBehaviour {
	Animator an;
	public GameObject camera;
	public customer_movement moving;
	public BurgerCheck bc;

	public float timer = 0;
	bool asd = true, qwe = true;
	// Use this for initialization
	void Start () {
		this.renderer.enabled = false;
		an = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	if (moving.currentCustomer != null) {
			if( bc.mistakes < 2 && bc.currentBurger != bc.maxSize)
			{
				if(asd)
				timer += Time.deltaTime;
				if(timer > .42f){
					this.renderer.enabled = true;
				an.SetBool("open", true);
				}
					if(timer > .48f)
					{
						qwe = true;
						asd = false;
						timer = 0;
						camera.SetActive(true);
					}
		}

			else{
				an.SetBool("open", false);
				asd = true;
				camera.SetActive(false);
				if(qwe)
				timer += Time.deltaTime;
				if(timer > .17f)
				{
					qwe = false;
					timer = 0;
					this.renderer.enabled = false;
				}
			}
		}

	}
}
