using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refelection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {

        Debug.DrawLine(transform.position, transform.up, Color.green);

        if (Input.GetMouseButtonDown(0))
        {
           
            Debug.DrawLine(transform.position, transform.up, Color.red, 3.0f);
            Debug.Log("shoot");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 100.0f);

            if (hit.collider != null )
            {
                Debug.Log("hit " + hit.collider.name);
                //repeat for other faces
                // bottom collider
                if (hit.collider.gameObject.GetComponentInParent<Mirror>().positive == true && hit.collider.gameObject.name == "Bottomcollider")
                {
                    Debug.Log("Shoot Left");

                }
                else if (hit.collider.gameObject.GetComponentInParent<Mirror>().positive == false && hit.collider.gameObject.name == "Bottomcollider")
                {
                    Debug.Log("Shoot Right");
                }
            }

        }

    }
}
