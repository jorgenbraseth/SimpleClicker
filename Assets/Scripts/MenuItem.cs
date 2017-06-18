using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItem : MonoBehaviour {

	public Tile builds;

	private static Color FADED = new Color (255, 255, 255, 0.5f);
	private static Color FULL = new Color (255, 255, 255, 1f);


	void OnMouseEnter(){
		GetComponent<SpriteRenderer> ().color = FULL;
		transform.GetChild (0).GetComponent<SpriteRenderer> ().color = FULL;
		GameState.instance.buildMenuSelection = builds;
	}

	void OnMouseExit(){
		GetComponent<SpriteRenderer> ().color  = FADED;
		transform.GetChild (0).GetComponent<SpriteRenderer> ().color  = FADED;
		GameState.instance.buildMenuSelection = null;
	}
}
