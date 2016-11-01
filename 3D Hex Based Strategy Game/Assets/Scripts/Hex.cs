using UnityEngine;
using System.Collections;

public class Hex : MonoBehaviour {

	//This hex's position
	public int x;
	public int y;
	Unit charInHex;

	public void switchToRed (){
		MeshRenderer mr = this.GetComponentInChildren<MeshRenderer>();
		if (mr.material.color != Color.red) {
			mr.material.color = Color.red;
		}
	}
	public void switchToWhite (){
		MeshRenderer mr = this.GetComponentInChildren<MeshRenderer>();
		if (mr.material.color != Color.white) {
			mr.material.color = Color.white;
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

	public void NowContainsChar(Unit u){
		// links the character to the hex
		charInHex = u;
	}

	public Unit CharInHex(){
		return charInHex;
	}

}
