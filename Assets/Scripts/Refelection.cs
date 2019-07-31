using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refelection : MonoBehaviour
{

    private int mirrorLayer = 1 << 8;
    private Vector3 leftOffset = new Vector3(-0.1f, 0, 0);
    private Vector3 rightOffset = new Vector3(0.1f, 0, 0);
    private Vector3 bottomOffset = new Vector3(0, -0.1f, 0);
    private Vector3 topOffset = new Vector3(0, 0.1f, 0);

    public Transform Waypointprefab;
	public Refelection refelection;

    public GameObject trail;
    public bool HasShot = false;

    // Use this for initialization
    void Start()
    {

    }
    void Update()
    {

        Debug.DrawLine(transform.position + topOffset, transform.up, Color.green);

        if (Input.GetKeyDown(KeyCode.Space) && !HasShot )
        {
            HasShot = true;
            ShootRay(this.transform.position, this.transform.up, mirrorLayer);
        }

    }


    void ShootRay(Vector3 origin, Vector3 direction , LayerMask layer)
    {

       // Debug.Log("shoot");
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, 100.0f, layer);
//        Debug.Log(hit.collider);
        //  Debug.DrawLine(origin, direction, Color.red, 3.0f);

        if (hit.collider == null)
        {
            Ray2D ray = new Ray2D(origin, direction);
            Debug.Log("n");
            Transform waypoint = Instantiate(Waypointprefab, ray.GetPoint(100.0f) , Quaternion.identity);
            trail.gameObject.GetComponent<pathFinder>().waypoints.Add(waypoint);
            trail.GetComponent<pathFinder>().runSonar = true;
        }
        
        if (hit.collider != null)
        {


            //  Debug.Log(hit.collider);
            if (hit.collider.gameObject.tag == "Mirror")
            {
               // Debug.Log("hit " + hit.collider.name);
                //repeat for other faces

                // bottom collider
                if (hit.collider.gameObject.GetComponentInParent<Mirror>().positive == true && hit.collider.gameObject.name == "Bottomcollider")
                {
                   // Debug.Log("Shoot Left");
                    ShootRay(hit.collider.transform.parent.GetChild(1).position + leftOffset, new Vector3(-90.0f, 0, 0) , mirrorLayer);
                    Debug.DrawRay(hit.collider.transform.parent.GetChild(1).position + leftOffset, new Vector3(-90.0f, 0, 0), Color.yellow);
                    Transform waypoint = Instantiate(Waypointprefab, new Vector3(hit.collider.transform.parent.GetChild(1).position.x, hit.collider.transform.parent.GetChild(1).position.y), Quaternion.identity);
                    trail.gameObject.GetComponent<pathFinder>().waypoints.Add(waypoint);
                    hit = new RaycastHit2D();

                }
                else if (hit.collider.gameObject.GetComponentInParent<Mirror>().positive == false && hit.collider.gameObject.name == "Bottomcollider")
                {
                   // Debug.Log("Shoot Right");
                    ShootRay(hit.collider.transform.parent.GetChild(3).position + rightOffset, new Vector3(90.0f, 0, 0), mirrorLayer);
                    Debug.DrawRay(hit.collider.transform.parent.GetChild(3).position + rightOffset, new Vector3(90.0f, 0, 0), Color.yellow);
                    Transform waypoint = Instantiate(Waypointprefab, new Vector3(hit.collider.transform.parent.GetChild(3).position.x, hit.collider.transform.parent.GetChild(3).position.y), Quaternion.identity);
                    trail.gameObject.GetComponent<pathFinder>().waypoints.Add(waypoint);
                    hit = new RaycastHit2D();

                }
                // top collider
                else if (hit.collider.gameObject.GetComponentInParent<Mirror>().positive == false && hit.collider.gameObject.name == "Topcollider")
                {
                  //  Debug.Log("Shoot Left");
                    ShootRay(hit.collider.transform.parent.GetChild(1).position + leftOffset, new Vector3(-90.0f, 0, 0), mirrorLayer);
                    Debug.DrawRay(hit.collider.transform.parent.GetChild(1).position + leftOffset, new Vector3(-90.0f, 0, 0), Color.red);
                    Transform waypoint = Instantiate(Waypointprefab, new Vector3(hit.collider.transform.parent.GetChild(1).position.x, hit.collider.transform.parent.GetChild(1).position.y), Quaternion.identity);
                    trail.gameObject.GetComponent<pathFinder>().waypoints.Add(waypoint);
                    hit = new RaycastHit2D();

                }
                else if (hit.collider.gameObject.GetComponentInParent<Mirror>().positive == true && hit.collider.gameObject.name == "Topcollider")
                {
                  //  Debug.Log("Shoot Right");
                    ShootRay(hit.collider.transform.parent.GetChild(3).position + rightOffset, new Vector3(90.0f, 0, 0), mirrorLayer);
                    Debug.DrawRay(hit.collider.transform.parent.GetChild(3).position + rightOffset, new Vector3(90.0f, 0, 0), Color.red);
                    Transform waypoint = Instantiate(Waypointprefab, new Vector3(hit.collider.transform.parent.GetChild(3).position.x, hit.collider.transform.parent.GetChild(3).position.y), Quaternion.identity);
                    trail.gameObject.GetComponent<pathFinder>().waypoints.Add(waypoint);
                    hit = new RaycastHit2D();

                }
                // left collider
                else if (hit.collider.gameObject.GetComponentInParent<Mirror>().positive == true && hit.collider.gameObject.name == "Lcollider")
                {
                  //  Debug.Log("Shoot Down");
                    ShootRay(hit.collider.transform.parent.GetChild(4).position + bottomOffset, new Vector3(0, -90.0f, 0), mirrorLayer);
                    Debug.DrawRay(hit.collider.transform.parent.GetChild(4).position + bottomOffset, new Vector3(0, -90.0f, 0), Color.blue);
                    Transform waypoint = Instantiate(Waypointprefab, new Vector3(hit.collider.transform.parent.GetChild(4).position.x, hit.collider.transform.parent.GetChild(4).position.y), Quaternion.identity);
                    trail.gameObject.GetComponent<pathFinder>().waypoints.Add(waypoint);
                    hit = new RaycastHit2D();

                }
                else if (hit.collider.gameObject.GetComponentInParent<Mirror>().positive == false && hit.collider.gameObject.name == "Lcollider")
                {
                  //  Debug.Log("Shoot Up");
                    ShootRay(hit.collider.transform.parent.GetChild(2).position + topOffset, new Vector3(0, 90.0f, 0), mirrorLayer);
                    Debug.DrawRay(hit.collider.transform.parent.GetChild(2).position + topOffset, new Vector3(0, 90.0f, 0), Color.green);
                    Transform waypoint = Instantiate(Waypointprefab, new Vector3(hit.collider.transform.parent.GetChild(2).position.x, hit.collider.transform.parent.GetChild(2).position.y), Quaternion.identity);
                    trail.gameObject.GetComponent<pathFinder>().waypoints.Add(waypoint);
                    hit = new RaycastHit2D();
                }

                // right collider
                else if (hit.collider.gameObject.GetComponentInParent<Mirror>().positive == false && hit.collider.gameObject.name == "Rcollider")
                {
                   // Debug.Log("Shoot Down");
                    ShootRay(hit.collider.transform.parent.GetChild(4).position + bottomOffset, new Vector3(0, -90.0f, 0), mirrorLayer);
                    Debug.DrawRay(hit.collider.transform.parent.GetChild(4).position + bottomOffset, new Vector3(0, -90.0f, 0), Color.blue);
                    Transform waypoint = Instantiate(Waypointprefab, new Vector3(hit.collider.transform.parent.GetChild(4).position.x, hit.collider.transform.parent.GetChild(4).position.y), Quaternion.identity);
                    trail.gameObject.GetComponent<pathFinder>().waypoints.Add(waypoint);
                    hit = new RaycastHit2D();

                }
                else if (hit.collider.gameObject.GetComponentInParent<Mirror>().positive == true && hit.collider.gameObject.name == "Rcollider")
                {
                  //  Debug.Log("Shoot Up");
                    ShootRay(hit.collider.transform.parent.GetChild(2).position + topOffset, new Vector3(0, 90.0f, 0), mirrorLayer);
                    Debug.DrawRay(hit.collider.transform.parent.GetChild(2).position + topOffset, new Vector3(0, 90.0f, 0), Color.green);
                    Transform waypoint = Instantiate(Waypointprefab, new Vector3(hit.collider.transform.parent.GetChild(2).position.x, hit.collider.transform.parent.GetChild(2).position.y), Quaternion.identity);
                    trail.gameObject.GetComponent<pathFinder>().waypoints.Add(waypoint);
                    hit = new RaycastHit2D();
                }
            }
            else if (hit.collider.gameObject.tag == "Goal")
            {
                //final waypoint added here
                Debug.Log("Hit Finish");
                Debug.Log("hit " + hit.collider.name);
                Transform waypoint = Instantiate(Waypointprefab, new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y), Quaternion.identity);
                trail.gameObject.GetComponent<pathFinder>().waypoints.Add(waypoint);
                trail.GetComponent<pathFinder>().runSonar = true;
                hit = new RaycastHit2D();
            }
        }
    }
}