using UnityEngine;
using System.Collections;

public class destroyBun : MonoBehaviour {
	Animator an;
	// Use this for initialization
	void Start () {
		 an = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	if (this.renderer.isVisible == false)
						Destroy (gameObject);
	}


	void OnCollisionEnter2D(Collision2D collider){
		if(collider.transform.position.y > this.transform.position.y && collider.transform.tag != "floor")
		an.SetBool ("squish", true);
	}
	void OnCollisionExit2D(Collision2D collider){
		if(collider.transform.position.y > this.transform.position.y)
			an.SetBool ("squish", false);
	}
}
