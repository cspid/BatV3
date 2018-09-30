using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Debug.DrawLine(transform.position,  new Vector3(100, transform.position.y), Color.green);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector3.right,100.0f);
            Debug.DrawLine(transform.position, new Vector3(100, transform.position.y), Color.red , 3.0f);

            if (hit != null && hit.collider != null && hit.collider)//hit.collider.gameObject.name == "Mirror")
            {
                Debug.Log(hit.collider.name);
                Vector3 inDirection = Vector3.Reflect(transform.right, hit.normal);

                Debug.DrawRay(hit.point, inDirection * 100, Color.red , 3.0f);
                hit = Physics2D.Raycast(hit.point + hit.normal * 0.01f, inDirection, 100.0f);

                if (hit != null && hit.collider != null)//hit.collider.gameObject.name == "Mirror")
                {
                    inDirection = Vector3.Reflect(inDirection, hit.normal);
                    Debug.DrawRay(hit.point, inDirection * 100, Color.red, 3.0f);

                    //Debug.DrawRay(hit.point, inDirection * 100, Color.red, 3.0f);
                    hit = Physics2D.Raycast(hit.point + hit.normal * 0.01f, inDirection, 100.0f);

                    if (hit != null && hit.collider != null)//hit.collider.gameObject.name == "Mirror")
                    {
                        inDirection = Vector3.Reflect(inDirection, hit.normal);
                        Debug.DrawRay(hit.point, inDirection * 100, Color.red, 3.0f);

                        //Debug.DrawRay(hit.point, inDirection * 100, Color.red, 3.0f);
                        hit = Physics2D.Raycast(hit.point + hit.normal * 0.01f, inDirection, 100.0f);


                    }

                }
            }

         }
		
	}

  

}
