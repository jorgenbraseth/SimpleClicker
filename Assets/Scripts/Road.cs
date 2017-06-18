using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : Buildable {

	private int NORTH = 1;
	private int EAST = 2;
	private int SOUTH = 4;
	private int WEST = 8;


	public Sprite[] neighbours;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		int sprite = 0;

		if (north != null && north is Road) {
			sprite = sprite | NORTH;
		}
		if (south != null && south is Road) {
			sprite = sprite | SOUTH;
		}
		if (west != null && west is Road) {
			sprite = sprite | WEST;
		}
		if (east != null && east is Road) {
			sprite = sprite | EAST;
		}

		GetComponent<SpriteRenderer> ().sprite = neighbours [sprite];
		
	}
}
