﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[TypeInfoBox("This script handles the level's win conditions and transitioning to the next scene")]
public class OnReturn : MonoBehaviour
{
    #region Variables

    #region Script Refs
    [FoldoutGroup("Script References")]
    public pathFinder pathFinderScript;
    [FoldoutGroup("Script References")]
    public Refelection refelection;
    [FoldoutGroup("Script References")]
    public Attempts attempts;
    [FoldoutGroup("Script References")]
    public OnHitGoal goalScript;
    [FoldoutGroup("Script References")]
    public ParticlesArea particlesArea;
    #endregion

    #region Material Refs
    [FoldoutGroup("Material References")]
    public Material whiteBatMaterial;
    [FoldoutGroup("Material References")]
    public Material whiteCircleMaterial;
    [FoldoutGroup("Material References")]
    public Material redBatMaterial;
    [FoldoutGroup("Material References")]
    public Material redCircleMaterial;
    [FoldoutGroup("Material References")]
    public Material blackMaterial;
    [FoldoutGroup("Material References")]
    public Material mirrorMaterial;
    #endregion

    #region Material Refs

    Color whiteColor;
	Color whiteCircleColor;
	Color redColor;
	Color redCircleColor;
	Color blackColor;
	Color mirrorColor;
    #endregion

    #region bool Refs
    [FoldoutGroup("Bools")]
    public bool whiteOut;
    [FoldoutGroup("Bools")]
    public bool whiteIn;
    [FoldoutGroup("Bools")]
    public bool redIn;
    [FoldoutGroup("Bools")]
    public bool mirrorOut;
    [FoldoutGroup("Bools")]
    public bool fadeIn = true;
    [FoldoutGroup("Bools")]
    public bool fadeToBlack;
    [FoldoutGroup("Bools")]
    public bool lerpIcon;
    bool nextScene;
    #endregion

    #region floats 
    //Fade Out
    [FoldoutGroup("Floats")]
    public float fadeSpeed = 0.03f;
    [FoldoutGroup("Floats")]
    public float fadeOutDelay = 0.03f;
    //Lerp
    [FoldoutGroup("Floats")]
    public float lerpTime = 2f;
    float currentLerpTime;
    float moveDistance = 10f;
    #endregion

    #region Transform Refs
    [FoldoutGroup("Transforms")]
    public Transform start;
    [FoldoutGroup("Transforms")]
    public Transform goal;
    [FoldoutGroup("Transforms")]
    public Transform startPos;
    [FoldoutGroup("Transforms")]
    public Transform endPos;
    [FoldoutGroup("Transforms")]
    public Transform counter;
    #endregion

    int levelScan = 1;

    #endregion
    void Start()
	{

		//counter.position = GameObject.Find("Red Goal").transform.position;


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

       // print( "LEVEL" + (levelScan + 1).ToString());


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
				print("white faded out, start fading red  Bat In");
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
				print("red bat faded in, start fading out mirrors");

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
                print("mirrors faded out, Start Lerp");
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
			//print(currentLerpTime);
            //When the red Icon is at start position, fade it out
            if (endPos.position == startPos.position)
            {
                //fade red
                redColor.a = redColor.a - fadeSpeed / 4;
                redBatMaterial.color = redColor;
                //fade red circle
                redCircleColor.a = redCircleColor.a - fadeSpeed / 4;
                redCircleMaterial.color = redCircleColor;
                //Bring back the white bat
                whiteColor.a = whiteColor.a + fadeSpeed / 3;
                whiteBatMaterial.color = whiteColor;

                if (redColor.a <= 0)
                {
					print("Red bat faded out, initializing next scene");
					
                    //levelScan += 1;
                    nextScene = true;
                    Destroy(endPos.gameObject);
                    print("Destroyed EndPos");
                    
                    lerpIcon = false;
                    particlesArea.gradient1 = true;

                }
                
            }
        }

        if(nextScene ==true){
            //Scan through level names to find the one that's enabled
            if (GameObject.Find("LEVEL" + levelScan.ToString()) == null)
            {
                levelScan++;
            } else {
                levelScan++;
                pathFinderScript.RunOnce = true;
				pathFinderScript.runSonar = false;
				pathFinderScript.waypoints.Clear();
//                Debug.Log("FUCK");
				refelection.HasShot = false;
                GameObject.Find("LEVEL" + (levelScan).ToString()).transform.GetChild(0).gameObject.SetActive(true); //Enable Next
                GameObject.Find("LEVEL" + (levelScan -1).ToString()).transform.GetChild(0).gameObject.SetActive(false); //Disable This
				//counter.position = GameObject.Find("Red Goal").transform.position;

                whiteIn = true; // fade in the sliders
                nextScene = false;


                //Reset End pos tranform, goal transform , goal script
                endPos = GameObject.Find("LEVEL" + (levelScan).ToString()).transform.GetChild(0).transform.GetChild(0).transform;
                goal = GameObject.Find("LEVEL" + (levelScan).ToString()).transform.GetChild(0).transform.GetChild(0).transform;
                goalScript = GameObject.Find("LEVEL" + (levelScan).ToString()).transform.GetChild(0).transform.GetChild(0).GetComponent<OnHitGoal>();
                attempts.SetNumberOfTries(levelScan -1);
                //move number of flips text to red circle it here




//                Debug.Log("FUCK2");
            }
        }
        if (whiteIn == true)
        {
//            Debug.Log("FUCK3");
            //Fade In Mirrors
            mirrorColor.a = mirrorColor.a + fadeSpeed / 3;
            mirrorMaterial.color = mirrorColor;
            //Fade in red bat
            // redColor.a = redColor.a + fadeSpeed / 4;
            // redBatMaterial.color = redColor;
            //Fade in red Circle
            
            redCircleColor.a = redCircleColor.a + fadeSpeed / 4;
            redCircleMaterial.color = redCircleColor;
            

            if (mirrorColor.a >= 1 && redCircleColor.a >= 1)
            {
                whiteIn = false;
           //     Debug.Log("FUCK4");
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
//                Debug.Log("FUCk5");

                whiteOut = true;
			}
		}
	}
}
