using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	public static GameState instance;

	[HideInInspector] public int cash;

	public Tile defaultGround;

	public SoundManager soundManager;

	private BuildMenu menuDisplayed;
	public Tile buildMenuSelection;

	public Tile hoveringOn;

	public void ShowMenu(Tile tile){
		if (tile == null) {
			return;
		}
		buildMenuSelection = null;
		menuDisplayed = tile.menu;
		menuDisplayed.gameObject.SetActive (true);
	}

	public void HideMenu(){
		menuDisplayed.gameObject.SetActive (false);
	}

	// Use this for initialization
	void Start () {
		if (instance != null) {
			Destroy (gameObject);
			return;
		}
		int xSize = 7;
		int ySize = 10;
		Tile[,] tiles = new Tile[xSize,ySize];

		instance = GetComponent<GameState>();
		soundManager = soundManager;
		cash = 20;

		float tileWidth = 2.1f;
		float tileHeight = 0.5f;

		for (int x = 0; x < xSize; x++) {
			for (int y = 0; y < ySize; y++) {
				float xOffset = -1 * xSize/2 * tileWidth;
				float yOffset = -1 * ySize/2 * tileHeight;

				float xPos = xOffset + x * tileWidth + (tileWidth / 2) * (y % 2);
				float yPos = yOffset + y * tileHeight;
				Tile groundPiece = Instantiate (defaultGround, new Vector3 (xPos, yPos, 0), Quaternion.identity);
				groundPiece.GetComponent<SpriteRenderer> ().sortingOrder = -y;
				groundPiece.x = x;
				groundPiece.y = y;
				tiles [x, y] = groundPiece;
			}
		}

		for (int x = 0; x < xSize; x++) {
			for (int y = 0; y < ySize-1; y++) {
				int northX = x + y % 2;
				int westX = x - ((y+1) % 2);

				if (northX < xSize) {
					tiles [x, y].north = tiles [northX, y + 1];
					tiles [northX, y + 1].south = tiles [x, y];
				} 

				if (westX >= 0) {
					tiles [x, y].west = tiles [westX, y+1];
					tiles [westX, y+1].east = tiles [x, y];
				}

			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			ShowMenu (hoveringOn);
		} else if (Input.GetMouseButtonUp (0)){ 
			if (buildMenuSelection != null) {
				Place(buildMenuSelection, menuDisplayed.tile);
			}
			if (menuDisplayed != null) {
				HideMenu ();
			}


		}

		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			GetComponent<Camera>().orthographicSize = Mathf.Min(Camera.main.orthographicSize+0.4f, 15);
		}else if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			GetComponent<Camera>().orthographicSize = Mathf.Max(Camera.main.orthographicSize-0.4f, 2);
		}
		
	}

	private void Place(Tile toPlace, Tile toReplace){
		Vector3 newPos = toReplace.transform.position;
		if (toPlace is Building && !(toReplace is Building) ) {
			newPos.y += 0.2f;
		}else if(!(toPlace is Building) && toReplace is Building){
			newPos.y -= 0.2f;
		}
			
		
		toReplace.ReplaceWith(Instantiate(toPlace, newPos, Quaternion.identity));
		if(toPlace is Buildable){
			soundManager.PlaySound (toPlace.GetComponent<Buildable> ().buildSound);
		}

	}


}
