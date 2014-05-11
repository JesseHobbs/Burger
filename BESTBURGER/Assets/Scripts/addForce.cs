using UnityEngine;
using System.Collections;

public class addForce : MonoBehaviour {
	Vector2 asd;
	[HideInInspector]
	public int force;
	Animator an;
	float Timer;
	public bool applyForce;
	bool notBouncing = true;

	void Start(){
		if(GetComponent<Animator>() != null)
		an = GetComponent<Animator> ();
		}

	void Update () {
		asd = new Vector2 (0, force);

		if (renderer.isVisible == false)
			Destroy (gameObject);
	}

	public void Forcer ()
	{
		if(applyForce)
			rigidbody2D.AddForce(asd);
	}

	void OnCollisionEnter2D(Collision2D collider){
		if (applyForce) {

						if (notBouncing && collider != null){
						notBouncing = false;
			BurgerBounce.ingredientsToBounce++;
			}
				}
		}

	void OnCollisionStay2D(Collision2D collider){

		if(an != null && collider.transform.position.y > transform.position.y)
		an.SetBool ("squish", true);
	


	}

	void OnCollisionExit2D(Collision2D collider){
		if(applyForce){
		if (!notBouncing) {
						BurgerBounce.ingredientsToBounce--;
						notBouncing = true;
			if(an != null)
			an.SetBool ("squish", false);
	}
	}
}
}