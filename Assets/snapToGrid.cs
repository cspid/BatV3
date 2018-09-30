using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class snapToGrid : MonoBehaviour {


    public string mirrorPosition;
    GameObject foundPosition;

	void Update () {
        if (GameObject.Find(mirrorPosition) != null)  //If we input a value
        {             
            foundPosition = GameObject.Find(mirrorPosition);            //Find The Object with the coordinate we enter
            if (foundPosition != null)
            {
                if (foundPosition.transform.position != transform.position)     //If it's not alread been moved                                                                              //print("HAS VALUE");
                    transform.position = foundPosition.transform.position;      //Move to that position
            }
        }
	}
}
