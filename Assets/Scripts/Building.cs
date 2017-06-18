using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Buildable {

	public int income;

	public float autoHarvestTime;

	public Buildable upgradesTo;

	private float timeToIncome;

	private bool isAutoharvesting;

	void Awake(){
		InitMenu ();
		timeToIncome = autoHarvestTime;
		isAutoharvesting = timeToIncome > 0;
	}

	// Update is called once per frame
	void Update () {
		if (isAutoharvesting) {
			
			timeToIncome -= Time.deltaTime;

			if (timeToIncome < 0) {
				timeToIncome += autoHarvestTime;
				GainIncome ();
			}
		}
	}

	public GameObject coin;

//	void OnMouseDown() {
//
//		if(Input.GetKey(KeyCode.LeftShift)) {
//			Upgrade ();		
//		} else {
//			GainIncome ();		
//
//		}
//		
//	}

	private void Upgrade() {
		if (upgradesTo == null || GameState.instance.cash < upgradesTo.cost) {
			GameState.instance.soundManager.PlayError ();
			return;
		}

		GameState.instance.cash -= upgradesTo.cost;
		Buildable built = Instantiate (upgradesTo, transform.position, transform.rotation);
		GameState.instance.soundManager.PlaySound (built.buildSound);
		ReplaceWith (built);

	}

	private void GainIncome(){
		Transform t = transform;
		GameState.instance.cash += income;
		Instantiate (coin, t.position, t.rotation); 
	}
}
