using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	public GameObject hexPrefab;

	//size of the map by hex tiles
	int width = 20;
	int height = 20;

	//offsets to line up hex tiles
	float xOffset = 1.77f;
	float zOffset = 1.531f;

	// Use this for initialization
	void Start () {
	
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {

				float xPos = x * xOffset;

				if (y % 2 == 1) {
					xPos += xOffset/2;
				}

				GameObject hex_go = (GameObject)Instantiate (hexPrefab, new Vector3(xPos,0, y * zOffset), Quaternion.identity);

				hex_go.name = "Hex_" + x + "_" + y;

				// give hexes their position so they can calculate their neighbors
				hex_go.GetComponent<Hex> ().x = x;
				hex_go.GetComponent<Hex> ().y = y;

				hex_go.transform.SetParent (this.transform);
			
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
