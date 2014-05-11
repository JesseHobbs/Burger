using UnityEngine;
using System.Collections;

public class toggle : MonoBehaviour {
	bool toggled;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown ("t")) {

			if(!toggled)
			{
				toggled = true;
				this.renderer.enabled = false;
			}
			else
			{
				toggled = false;
				this.renderer.enabled = true;
			}

				}
	}
}
