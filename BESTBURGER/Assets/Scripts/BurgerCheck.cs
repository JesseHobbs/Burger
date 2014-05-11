using UnityEngine;
using System.Collections;

public class BurgerCheck : MonoBehaviour {
	// order is used to compare to player input to see if it is correct, order text is what appears on screen. ingredientsList is the individual ingredients to display
	bool addTime = false;
	[HideInInspector]
	string order, playerInput, orderText;
	string[] ingredientList;
	//maxSize is used to get a new size for the burger each order. TotalBurger is used to grab that size and compare to currentBurger.
	[HideInInspector]
	public int totalBurger, currentBurger, maxSize, mistakes;
	public int timeAdditionAmount;
	public float winWaitTime, failWaitTime;
	float timer = 0;
	// allowInput is to prevent players from pressing buttons while there is no order. Won is used to help display the win/loss
	[HideInInspector]
	public bool allowInput = false,won = false;
	public bool allowTimeAddition;
	GameObject[] an;
	// indexes used to fill the orderText and also to change text color
	[HideInInspector]
	public int i = 0,currentI = 0;
	public Timer clock;
	public WinLoss winLoss;
	public customer_movement moving;
	// default win wait time is .82, failure is 2f

	public AudioClip[] sfx;
	bool playOnce = true;
	void Start () {
		maxSize = Random.Range (3, 6);
		ingredientList = new string[maxSize];
	}

	void Update () {
		// Inputs


		an = GameObject.FindGameObjectsWithTag("customer");
		if (clock.clockTimer <= 0)
		{
			guiText.text = "TIME!";
			if(an != null)
			foreach(GameObject e in an)
			{
				Animator asd = e.GetComponent<Animator>();
				asd.SetBool("angry", true);
			}
			return;
		}



		if (currentBurger < maxSize && totalBurger != 0 && moving.inPosition == true)
						allowInput = true;

		if (allowInput) {
						if (Input.GetButtonDown ("Grilled")) {
								playerInput += "G";
								currentBurger++;
						}
						else if (Input.GetButtonDown ("Lettuce")) {
								playerInput += "L";
								currentBurger++;
						}
						else if (Input.GetButtonDown ("Cheese")) {
								playerInput += "C";
								currentBurger++;
						}
						else if (Input.GetButtonDown ("Tomato")) {
								playerInput += "T";
								currentBurger++;
						}
						else if (Input.GetButtonDown ("Bacon")) {
								playerInput += "B";
								currentBurger++;

						}
			}

		// use to get the current index of order and playerinput, compare the two and see if they match. Then changes the color of the text based on the comparisson
		currentI = currentBurger - 1;
		if ((Input.GetButtonDown ("Grilled") ||Input.GetButtonDown ("Cheese")||Input.GetButtonDown ("Lettuce")||
		     Input.GetButtonDown ("Bacon")||Input.GetButtonDown ("Tomato"))&& currentI != -1 && mistakes <2){

				if ( order [currentI] == playerInput [currentI]) 
			{

				ingredientList [currentI] = "<color=blue>" + ingredientList [currentI] + "</color>";
				orderText = null;
				i = 0;
				audio.clip = sfx[2];
				if(moving.inPosition)
				audio.Play();
			}
			if(Input.anyKeyDown && order [currentI] != playerInput [currentI]){
				ingredientList [currentI] = "<color=maroon>" + ingredientList [currentI] + "</color>";
				orderText = null;
				mistakes++;
				i = 0;
				audio.clip = sfx[0];
				if(moving.inPosition)
				audio.Play();
			}
				
		}
		// Add ingredients until the max number is reached
		if (totalBurger != maxSize) 
						ChooseIngredients ();


		//check the order to see if input was correct
		if (currentBurger >= maxSize || mistakes >=2) {
			if(mistakes == 0)
			{
				orderText = "PERFECT!";
				won = true;	
				winLoss.Scoring();
				if(!addTime && allowTimeAddition){
				clock.clockTimer += timeAdditionAmount;
					addTime = true;

				}
			}
			// if only one mistake
			if(mistakes == 1)
			{
				orderText = "OK!";
				won = true;	
				winLoss.Scoring();
				if(!addTime && allowTimeAddition){
					clock.clockTimer += timeAdditionAmount / 2;
					addTime = true;
				}
			}
			// if too many mistakes
			if(mistakes >= 2){
				orderText = "NO!";
				winLoss.Scoring();
				foreach(GameObject e in an)
				{
					audio.clip = sfx[1];
					if(playOnce){
					audio.Play();
						playOnce = false;
					}
					Animator asd = e.GetComponent<Animator>();
					asd.SetBool("angry", true);
				}
				won = false;
			}

			//Reset EVERYTHING
			timer += Time.deltaTime;
			if (timer >= failWaitTime || (currentBurger == maxSize && mistakes < 2 && timer >= winWaitTime)) {
				BurgerBounce.ingredientsToBounce = 0;
				BurgerBounce.Reset = true;
				foreach(GameObject e in an)
				{
					Animator asd = e.GetComponent<Animator>();
					asd.SetBool("angry", false);
				}
				winLoss.stopAdding = false;
				mistakes = 0;
				addTime = false;
				playerInput = null;
				order = null;
				orderText = null;
				currentBurger = 0;
				totalBurger = 0;
				maxSize = Random.Range (3, 6);
				ingredientList = new string[maxSize];
				i = 0;
					timer = 0;
				moving.move = true;

				playOnce = true;
				}
				}



		// disallow input
		if (totalBurger <= currentBurger || totalBurger == 0 || !moving.inPosition)
			allowInput = false;
	
		//show the ingredient list only when all ingredients are accounted for
		if (totalBurger != maxSize || !moving.inPosition)
						guiText.text = null;

			else{ // the currentBurger != maxSize is used to stop additional text being added when the burger is finished
				if(i < maxSize && currentBurger != maxSize && mistakes != 2)
					orderText += ingredientList[i];
					i++;

				if(i == maxSize)
					guiText.text = orderText;
		}
}

	void ChooseIngredients ()
	{// only allows ingredients to be added if the npc is in position.
		if(moving.inPosition)
						for (int i = 0; i < maxSize; i++) {
								int ingredients = Random.Range (1, 6);
		
								if (ingredients == 1) {
										order += "L";
										totalBurger++;    
										ingredientList [i] += "Lettuce\n";
								}
								if (ingredients == 2) {
										order += "C";
										totalBurger++;
										ingredientList [i] += "Cheese\n";
										;
								}
								if (ingredients == 3) {
										order += "T";
										totalBurger++;
										ingredientList [i] += "Tomato\n";
										;
								}
								if (ingredients == 4) {
										order += "B";
										totalBurger++;
										ingredientList [i] += "Bacon\n";
										;
								}
								if (ingredients == 5) {
										order += "G";
										ingredientList [i] += "Burger \n";
										totalBurger++;
								}
						}
				else
						return;
	}
}