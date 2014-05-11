using UnityEngine;
using System.Collections;

public class BurgerBounce : MonoBehaviour {
	public Transform spawnPoint;
	Vector3  defaultPos;
	public GameObject patty, lettuce, cheese, tomato, bacon,bottomBun, Topbun;
	[HideInInspector]
	public GameObject[] burgerInProgress;
	[HideInInspector]
	public static int ingredientsToBounce;
	[HideInInspector]
	public int burgerIndex = 0, asdd;
	float Timer;
	addForce extraForce;
	public customer_movement moving;
	public BurgerCheck bc;
	float timer = 0;
	public static bool Reset;
	public float bouncePace;

	void Start () {
		defaultPos = spawnPoint.position;
		}
	// Update is called once per frame
		void Update () {

		if (bc.mistakes == 2)
						collider2D.enabled = false;
				else
						collider2D.enabled = true;

		asdd = ingredientsToBounce;
				if (burgerInProgress.Length != bc.maxSize + 2)
						burgerInProgress = new GameObject[bc.maxSize + 2];

				if (Reset) {
			spawnPoint.position = defaultPos;

						timer += Time.deltaTime;
						if (timer > .1f) {
								timer = 0;
								for (int i = 0; i < burgerInProgress.Length; i++) {
										Destroy (burgerInProgress [i]);
								}
				ingredientsToBounce = 0;
								burgerInProgress = new GameObject[bc.maxSize + 2];
								burgerIndex = 0;
								GameObject spawned = Instantiate (bottomBun, spawnPoint.position, Quaternion.identity) as GameObject;
								burgerInProgress [burgerIndex] = spawned;
								spawned.transform.parent = GameObject.Find ("HAMBURGER").transform;
								burgerIndex++;
								Reset = false;
						}
				}
				if (bc.i < bc.maxSize && burgerIndex < bc.maxSize + 2 && bc.totalBurger != 0 && bc.mistakes <2) {
						if (burgerIndex == 0) {
								GameObject spawned = Instantiate (bottomBun, spawnPoint.position, Quaternion.identity) as GameObject;
								burgerInProgress [burgerIndex] = spawned;
								burgerIndex++;
								spawned.transform.parent = GameObject.Find ("HAMBURGER").transform;
						}
			if(moving.inPosition){
						if (Input.GetButtonDown ("Grilled")) {
								GameObject spawned = Instantiate (patty, spawnPoint.position, Quaternion.identity) as GameObject;
								burgerInProgress [burgerIndex] = spawned;
								burgerInProgress [burgerIndex].GetComponent<addForce> ().force = 24 + (burgerIndex * 4);
								burgerIndex++;
								spawned.transform.parent = GameObject.Find ("HAMBURGER").transform;
								spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x,spawnPoint.transform.position.y + .28f, -5.4f);
								
						} else if (Input.GetButtonDown ("Lettuce")) {
								GameObject spawned = Instantiate (lettuce,new Vector3( spawnPoint.position.x,spawnPoint.position.y,spawnPoint.position.z - .5f), Quaternion.identity) as GameObject;
								burgerInProgress [burgerIndex] = spawned;
								burgerInProgress [burgerIndex].GetComponent<addForce> ().force = 24 + (burgerIndex * 4);
								burgerIndex++;
								spawned.transform.parent = GameObject.Find ("HAMBURGER").transform;
				spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x,spawnPoint.transform.position.y + .28f, -5.4f);
			
						} else if (Input.GetButtonDown ("Cheese")) {
								GameObject spawned = Instantiate (cheese, spawnPoint.position, Quaternion.identity) as GameObject;
								burgerInProgress [burgerIndex] = spawned;
								burgerInProgress [burgerIndex].GetComponent<addForce> ().force = 24 + (burgerIndex * 4);
								burgerIndex++;
								spawned.transform.parent = GameObject.Find ("HAMBURGER").transform;
				spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x,spawnPoint.transform.position.y + .28f, -5.4f);
			
						} else if (Input.GetButtonDown ("Tomato")) {
								GameObject spawned = Instantiate (tomato, spawnPoint.position, Quaternion.identity) as GameObject;
								burgerInProgress [burgerIndex] = spawned;
								burgerInProgress [burgerIndex].GetComponent<addForce> ().force = 24 + (burgerIndex * 4);
								burgerIndex++;
								spawned.transform.parent = GameObject.Find ("HAMBURGER").transform;
				spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x,spawnPoint.transform.position.y + .28f, -5.4f);

						} else if (Input.GetButtonDown ("Bacon")) {
								GameObject spawned = Instantiate (bacon, spawnPoint.position, Quaternion.identity) as GameObject;
								burgerInProgress [burgerIndex] = spawned;
								burgerInProgress [burgerIndex].GetComponent<addForce> ().force = 24 + (burgerIndex * 4);
								burgerIndex++;
								spawned.transform.parent = GameObject.Find ("HAMBURGER").transform;
				spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x,spawnPoint.transform.position.y + .28f, -5.4f);
						}
			
						if (burgerIndex == burgerInProgress.Length - 1 && GameObject.FindGameObjectWithTag("bottombun")) {
								GameObject spawned = Instantiate (Topbun, new Vector3 (spawnPoint.position.x, spawnPoint.position.y + .5f, spawnPoint.position.z), Quaternion.identity) as GameObject;
								burgerInProgress [burgerIndex] = spawned;
								burgerIndex++;
			
								spawned.transform.parent = GameObject.Find ("HAMBURGER").transform;
						}
				}
	}

				if (ingredientsToBounce == burgerIndex - 1) {
					 
								Timer += Time.deltaTime;
			
								if(Timer > bouncePace){
										foreach (GameObject e in burgerInProgress) {
												if (e != null && e.GetComponent<addForce> () != null)
														e.GetComponent<addForce> ().Forcer ();
										}
								Timer = 0;
								}
							}
						}
}