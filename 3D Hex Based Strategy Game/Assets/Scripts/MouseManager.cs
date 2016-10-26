using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);  //shoots a ray from camera to mouse position
		RaycastHit hitInfo; //hitInfo instantiation is required so Raycast can output the object it is hitting

		if (Physics.Raycast(ray, out hitInfo)) {
			GameObject ourHitObject = hitInfo.collider.transform.parent.gameObject;

			Debug.Log ("Raycast hit " + ourHitObject.name); // transform parent name to get the object hexagon's parent which has the more useful name

			if (Input.GetMouseButtonDown(0)) {
				MeshRenderer mr = ourHitObject.GetComponentInChildren<MeshRenderer> ();
	
				Hex[] neighbors = (Hex)ourHitObject.GetNeighbors ();

				if (mr.material.color == Color.red) {
					mr.material.color = Color.white;
				} else {
					mr.material.color = Color.red;
				}

			}
		}

		//for an FPS, it would look like this
		//Ray fpsRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		//shoots out a ray from the camera to the center of the screen.
	}
}
