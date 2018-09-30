using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnReturn : MonoBehaviour
{
    //This script handles the level's win conditions and transitioning to the next scene
	public OnHitGoal goalScript;
	public ParticlesArea particlesArea;

	public Material whiteBatMaterial;
	public Material whiteCircleMaterial;
	public Material redBatMaterial;
	public Material redCircleMaterial;
	public Material blackMaterial;
	public Material mirrorMaterial;

	Color whiteColor;
	Color whiteCircleColor;
	Color redColor;
	Color redCircleColor;
	Color blackColor;
	Color mirrorColor;
    
	public float fadeSpeed = 0.03f;
   
	public bool whiteOut;
	public bool redIn;
	public bool mirrorOut;

	public bool fadeIn = true;
	public bool fadeToBlack;
	public bool lerpIcon;
    
	public float fadeOutDelay = 0.03f;

	public Transform start;
	public Transform goal;

    //Lerp
	public float lerpTime = 2f;
    float currentLerpTime;

    float moveDistance = 10f;

    public Transform startPos;
    public Transform endPos;
 
	void Start()
	{
        //Set white material
		whiteColor = new Color(1, 1, 1, 1);
		whiteBatMaterial.color = whiteColor;
	    
		//Set red material
		redColor = new Color(0.95f, 0.125f, 0.125f, 0);
        redBatMaterial.color = redColor;
        
		//Set redCircle material
        redCircleColor = new Color(0.95f, 0.125f, 0.125f, 1);
        redCircleMaterial.color = redCircleColor;

		//Set whiteCircle material
        whiteCircleColor = new Color(1f, 1f, 1f, 1);
        whiteCircleMaterial.color = whiteCircleColor;

        //Set mirror material
        mirrorColor = new Color(1, 1, 1, 1);
        mirrorMaterial.color = mirrorColor;
		
		//Set black material
		blackColor = new Color(0, 0, 0, 1);
		blackMaterial.color = blackColor;
		
        
	}
 

    void Update()
    {

        //fade in from black
		if (fadeIn == true)
        {
            blackColor.a = blackColor.a - fadeSpeed / 3;
            blackMaterial.color = blackColor;

            if (blackColor.a <= 0)
            {
				fadeIn = false;
            }
        }

		//fade out the white bat
        if (whiteOut == true)
        {
            whiteColor.a = whiteColor.a - fadeSpeed/3;
            whiteBatMaterial.color = whiteColor;
            
            if (whiteColor.a <= 0){
                redIn = true;
                whiteOut = false;
            }
        }

        //Fade in the red bat
        if (redIn == true)
        {
            redColor.a = redColor.a + fadeSpeed/4;
            redBatMaterial.color = redColor;

            if (redColor.a >= 1)
            {
                redIn = false;             
				mirrorOut = true;
				print("fade out red");

            }      
        }

        //Fade Out the Mirrors
		if (mirrorOut == true)
        {
            mirrorColor.a = mirrorColor.a - fadeSpeed;
            mirrorMaterial.color = mirrorColor;
            
            if (mirrorColor.a <= 0)
            {
				currentLerpTime = 0f;   //Set up the lerp
				lerpIcon = true;
                mirrorOut = false;
                print("fade mirrors out");
            }
        }

		//Lerp the red icon to the white icon
		if (lerpIcon == true)
		{
			currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            //lerp!
            float t = currentLerpTime / lerpTime;
            endPos.position = Vector3.Lerp(endPos.position, startPos.position, t);
		
            //When the red Icon is at start position, fade it out
    		if(endPos.position == startPos.position){
                    //fade red
    				redColor.a = redColor.a - fadeSpeed/4;
                    redBatMaterial.color = redColor;
                    //fade red circle
    				redCircleColor.a = redCircleColor.a - fadeSpeed / 4;
                    redCircleMaterial.color = redCircleColor;
                    //Bring back the white bat
    				whiteColor.a = whiteColor.a + fadeSpeed / 3;
                    whiteBatMaterial.color = whiteColor;

                if (redColor.a <= 0)
                {   
    				Destroy(endPos.gameObject);
                    print("Destroyed EndPos");
					lerpIcon = false;
					particlesArea.gradient1 = true;
                }      
    		}

        }
    }




	void OnTriggerEnter(Collider other)
	{
		//If we meet these conditions we have completed the level - run OnReturnActions
		if (goalScript != null)
		{
			if (other.gameObject.tag == "trail" && goalScript.hitGoal == true)
			{
				print("Returned Home");
				//begin win conditions
				whiteOut = true;
			}
		}
	}
}
