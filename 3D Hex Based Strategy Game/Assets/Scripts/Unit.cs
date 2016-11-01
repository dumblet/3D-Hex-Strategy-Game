using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	// Use this for initialization
	public Vector3 destination;
	float speed = 2;

	// gives which hex it is currently on
	public int loc_x;
	public int loc_y;


	// Use this for initialization
	void Start () {
		loc_x = 0;
		loc_y = 0;
		destination = transform.position;
	}

	// Update is called once per frame
	void Update () {
		//move towards destination

		Vector3 dir = destination - transform.position;
		Vector3 velocity = dir.normalized * speed * Time.deltaTime;

		velocity = Vector3.ClampMagnitude (velocity, dir.magnitude);

		transform.Translate (velocity);
	}
}
