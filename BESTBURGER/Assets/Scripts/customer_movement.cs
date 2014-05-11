using UnityEngine;
using System.Collections;

public class customer_movement : MonoBehaviour {

	public Transform start,wait,leave;
	[HideInInspector]
	public GameObject customer,currentCustomer;
	public float speed;
	[HideInInspector]
	public bool inPosition;
	public int oddballOccurance;
	int randomCustomer, randomSpecial, normalOrSpecial;
	[HideInInspector]
	public bool move = false;
	float moveSpeed;
/* Customer Ranges :
					* Tees 1-25
					* Hoodies 26-50
					* 
					* speed is 10 by default
*/


	void Start () {
		randomCustomer = Random.Range (1, 51);
		customer = Resources.Load ("" + randomCustomer) as GameObject;
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (currentCustomer != null && (currentCustomer.transform.position == wait.position))
						inPosition = true;
				else
						inPosition = false;


		moveSpeed = speed * Time.deltaTime;

		if(customer && !currentCustomer){
		currentCustomer = Instantiate(customer,start.position,Quaternion.identity) as GameObject;
		}
		if(!move)
			currentCustomer.transform.position = Vector3.MoveTowards(currentCustomer.transform.position, wait.position, moveSpeed);
		if(move)
			currentCustomer.transform.position = Vector3.MoveTowards(currentCustomer.transform.position, leave.position, 10f * Time.deltaTime);

		if(currentCustomer.transform.position == leave.position)
		{
			move = false;
			// determine to use normal or special npcs
			normalOrSpecial = Random.Range(1,oddballOccurance);

			if(normalOrSpecial == oddballOccurance - 1f)
			{
				randomCustomer = Random.Range (1, 8);
				customer = Resources.Load ("oddballs/" + randomCustomer) as GameObject;
			}
			else{
			randomCustomer = Random.Range (1, 51);
			customer = Resources.Load ("" + randomCustomer) as GameObject;
			}
			Destroy(currentCustomer);
		}
	}

}