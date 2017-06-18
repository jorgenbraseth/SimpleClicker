using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateText ();
	}

	private void UpdateText(){
		Text t = GetComponent<Text>();
		t.text = ""+GameState.instance.cash;
	}
}
