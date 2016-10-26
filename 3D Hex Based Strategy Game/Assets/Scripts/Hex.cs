using UnityEngine;
using System.Collections;

public class Hex : MonoBehaviour {

	//This hex's position
	int x;
	int y;

	public Hex LeftNeighbor(){
		GameObject left = GameObject.Find ("Hex_" + (x - 1) + "_" + y);
		return left; 
	}

	public Hex[] GetNeighbors(){

		//Hex[0] is left neighbor, goes clockwise, hex[5] is botleft

		GameObject left, right, topRight, topLeft, botRight, botLeft;

		left = GameObject.Find ("Hex_" + (x - 1) + "_" + y);

		right = GameObject.Find ("Hex_" + (x + 1) + "_" + y);


		if (y%2 == 0) {
			topRight = GameObject.Find ("Hex_" + (x) + "_" + (y + 1));
			topLeft = GameObject.Find ("Hex_" + (x - 1) + "_" + (y + 1));
			botRight = GameObject.Find ("Hex_" + (x) + "_" + (y - 1));
			botLeft = GameObject.Find ("Hex_" + (x - 1) + "_" + (y - 1));
		} else {

			topRight = GameObject.Find ("Hex_" + (x + 1) + "_" + (y + 1));
			topLeft = GameObject.Find ("Hex_" + (x) + "_" + (y + 1));
			botRight = GameObject.Find ("Hex_" + (x + 1) + "_" + (y - 1));
			botLeft = GameObject.Find ("Hex_" + (x) + "_" + (y - 1));
		}

		Hex [0] = left;
		Hex [1] = topLeft;
		Hex [2] = topRight;
		Hex [3] = right;
		Hex [4] = botRight;
		Hex [5] = botLeft;

		return Hex;

	}
}
