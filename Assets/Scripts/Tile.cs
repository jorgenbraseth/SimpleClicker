using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	[HideInInspector] public Tile north;
	[HideInInspector] public Tile south;
	[HideInInspector] public Tile west;
	[HideInInspector] public Tile east;

	[HideInInspector] public int x;
	[HideInInspector] public int y;

	public BuildMenu menuType;
	[HideInInspector] public BuildMenu menu;
	public Buildable[] buildable;

	protected void InitMenu(){
		menu = Instantiate (menuType, transform.position, Quaternion.identity);
		if (buildable.Length > 0) {
			Transform option1 = menu.transform.FindChild ("option1");
			option1.gameObject.SetActive (true);
			option1.GetComponent<MenuItem> ().builds = buildable [0];
			option1.GetChild (0).GetComponent<SpriteRenderer> ().sprite = buildable [0].GetComponent<SpriteRenderer> ().sprite;
		}
		if (buildable.Length > 1) {
			Transform option2 = menu.transform.FindChild ("option2");
			option2.gameObject.SetActive (true);
			option2.GetComponent<MenuItem> ().builds = buildable [1];
			option2.GetChild (0).GetComponent<SpriteRenderer> ().sprite = buildable [1].GetComponent<SpriteRenderer> ().sprite;
		}
		menu.tile = GetComponent<Tile> ();
		menu.gameObject.SetActive (false);
	}

	void Awake() {
		InitMenu ();

	}

	void OnMouseEnter(){
		Tile h;
		h = GetComponent<Tile> ();
		GameState.instance.hoveringOn = h;
		Debug.Log (ToString ());
	}

	public void ReplaceWith(Tile replacement){
		replacement.GetComponent<SpriteRenderer> ().sortingOrder = GetComponent<SpriteRenderer> ().sortingOrder;
		replacement.north = north;
		replacement.south = south;
		replacement.east = east;
		replacement.west = west;

		if(north != null)
			north.south = replacement;
		if(south != null)
			south.north = replacement;
		if(west != null)
			west.east = replacement;
		if(east != null)
			east.west = replacement;
		Destroy (gameObject);
	}

}
