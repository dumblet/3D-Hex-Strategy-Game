using UnityEngine;
using System.Collections;

public class Hex : MonoBehaviour {

	//This hex's position
	public int x;
	public int y;
	public int colorMode = 0; //1 if red, 0 if white. for game over purposes

	public int switchColor (){
		MeshRenderer mr = this.GetComponentInChildren<MeshRenderer>();
		if (mr.material.color == Color.red) {
			mr.material.color = Color.white;
			return -1;
		} else {
			mr.material.color = Color.red;
			return 1;
		}
	}


	public GameObject[] GetNeighbors(){

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
			
		GameObject[] neighbors = new GameObject[6];
		if (left != null) {
			neighbors [0] = left;
		}
		if (topLeft != null) {
			neighbors [1] = topLeft;
		}
		if (topRight != null) {
			neighbors [2] = topRight;
		}
		if (right != null) {
			neighbors [3] = right;
		}
		if (botRight != null) {
			neighbors [4] = botRight;
		}
		if (botLeft != null) {
			neighbors [5] = botLeft;
		}

		return neighbors;

	}

}
