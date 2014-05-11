using UnityEngine;
using System.Collections;
public class WinLoss : MonoBehaviour {

	public int perfects,okays,failed,left;

	public BurgerCheck bc;
	[HideInInspector]
	public bool stopAdding = false;
	void Update () {
					guiText.text = left.ToString ();
				
	}

	public void Scoring()
	{if (!stopAdding) {
						if (bc.mistakes == 0){
								perfects++;
				left--;
			}
						if (bc.mistakes == 1){
								okays++;
				left--;
			}
						if (bc.mistakes == 2)
								failed++;

			stopAdding = true;
				}
		else
				return;
	}
}
