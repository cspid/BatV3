using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathFinder : MonoBehaviour
{

	public Transform[] waypoints;
	int waypointTarget = 0;
	public float speed;
	bool runSonar;


	// Use this for initialization
	void Enable () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			runSonar = true;
		}

		if (runSonar == true)
		{
			//move to the first waypoint
			transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointTarget].position, speed * Time.deltaTime);
            //set target to the next waypoint
			if (transform.position == waypoints[waypointTarget].position && waypointTarget < waypoints.Length - 1) waypointTarget++;
		}
	}
}
