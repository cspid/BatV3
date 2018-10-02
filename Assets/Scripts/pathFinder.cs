using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathFinder : MonoBehaviour
{

	public List<Transform>  waypoints;
	int waypointTarget = 0;
	public float speed;
	public bool runSonar;
    public bool RunOnce = true;
    public GameObject bat;
	// Use this for initialization
	void Enable () {
        waypoints = new List<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		

		if (runSonar == true)
		{
            if (RunOnce)
            {
                RunOnce = false;
                waypointTarget = waypoints.Count - 1;
            }
            //move to the first waypoint
			transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointTarget].position, speed * Time.deltaTime);
            //set target to the next waypoint
			if (transform.position == waypoints[waypointTarget].position && waypointTarget > 0) waypointTarget--;
            
           // runSonar = false;
          /* if(waypointTarget == 0)
            {
                waypoints.Clear();
                bat.gameObject.GetComponent<Refelection>().HasShot = false;
            }*/

		}
        // runSonar = false;
       
	}

     void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Exit" )
        {
            Debug.Log("Resart Here");
        }
        //ability to shoot new ray
        // reset waypoint list
    }


}
