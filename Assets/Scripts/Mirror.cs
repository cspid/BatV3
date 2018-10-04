using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Mirror : MonoBehaviour {

    public bool positive;
    public bool hasFlipped = false;

    private Attempts AttemptsScript;
	public Color switchColor;

    void Start()
    {
        AttemptsScript = GameObject.FindGameObjectWithTag("Bat").GetComponent<Attempts>();
    }
    // Use this for initialization
    void Update () {
        if (positive)
        {
            this.transform.GetChild(0).transform.rotation = new Quaternion(0, 0, 0, 0);
            this.transform.GetChild(0).transform.Rotate(Vector3.zero);
            this.transform.GetChild(0).transform.Rotate(0, 0, 45.0f);
        }
        else
        {
            this.transform.GetChild(0).transform.rotation = new Quaternion(0, 0, 0, 0);
            this.transform.GetChild(0).transform.Rotate(Vector3.zero);
            this.transform.GetChild(0).transform.Rotate(0, 0, -45.0f);
        }
	}
	 void OnMouseOver(){
       
        if (Input.GetMouseButtonUp(0))
        {
            print("switch");
            if (AttemptsScript.numberOfTries > 0)
            {
                if (hasFlipped)
                {
                    hasFlipped = false;
                    AttemptsScript.Add();

                    //fipped back
                    //change material back to normal here
					GetComponentInChildren<SpriteRenderer>().color = new Color(255, 255, 255, 1);


                }
                else
                {
                    hasFlipped = true;
                    AttemptsScript.Subtract();

					//has been flipped
					//change material here
					GetComponentInChildren<SpriteRenderer>().color = switchColor;
					print(transform.GetChild(1).name);
                }

                if (positive)
                {
                    positive = false;
                }
                else
                {
                    positive = true;
                }
            }
            else if(AttemptsScript.numberOfTries == 0 && hasFlipped == true)
            {
                hasFlipped = false;
                AttemptsScript.Add();

                //fipped back
                //change material back to normal here
				GetComponentInChildren<SpriteRenderer>().color = new Color(255, 255, 255, 1);
              
                if (positive)
                {
                    positive = false;
                }
                else
                {
                    positive = true;
                }
            }
        }
	}
	
}
