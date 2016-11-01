using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {

	//int totalReds = 0;
	//int totalHex = 0;

	PlayerUnit selectedPlayerUnit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);  //shoots a ray from camera to mouse position
		RaycastHit hitInfo; //hitInfo instantiation is required so Raycast can output the object it is hitting

		if (Physics.Raycast(ray, out hitInfo)) {
			GameObject ourHitObject = hitInfo.collider.transform.parent.gameObject;

			if (ourHitObject.GetComponent<Hex>() != null) {

				MouseOver_Hex (ourHitObject);
			}
			else if (ourHitObject.GetComponent<PlayerUnit>() != null) {

				MouseOver_Unit (ourHitObject);
			}



		}

		//for an FPS, it would look like this
		//Ray fpsRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		//shoots out a ray from the camera to the center of the screen.
	}

	void MouseOver_Hex(GameObject ourHitObject){
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log ("Raycast hit " + ourHitObject.name);
			//MeshRenderer mr = ourHitObject.GetComponentInChildren<MeshRenderer> ();
			// transform parent name to get the object hexagon's parent which has the more useful name
			Hex selectedHex = ourHitObject.GetComponent<Hex>();
			//selectedHex.switchColor ();

			if (selectedHex.CharInHex() != null) {
				selectedPlayerUnit = (PlayerUnit)selectedHex.CharInHex();
			}

			if (selectedPlayerUnit != null) {
				GameObject.Find ("Hex_" + selectedPlayerUnit.loc_x + "_" + selectedPlayerUnit.loc_y).GetComponent<Hex>().NowContainsChar(null);
				selectedPlayerUnit.destination = selectedHex.transform.position;
				selectedPlayerUnit.loc_x = selectedHex.x;
				selectedPlayerUnit.loc_y = selectedHex.y;
				selectedHex.NowContainsChar (selectedPlayerUnit);
			}

			//This code colors all neighbors
			int range = 2;


			GameObject[] neighbors = ourHitObject.GetComponent<Hex>().GetNeighbors ();

// WIP

			neighbors [0].GetComponent<Hex> ().GetNeighbors ();
			for (int i = 0; i < 6; i++) {
				if (neighbors [i] != null) {
					Debug.Log ("Hit neighbor " + neighbors [i].name);
					neighbors[i].GetComponent<Hex> ().switchToRed ();
				}
			}

		}
	}
	void MouseOver_Unit(GameObject ourHitObject){
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log ("Raycast hit " + ourHitObject.name);
			selectedPlayerUnit = ourHitObject.GetComponent<PlayerUnit>();
		}
	}
}
