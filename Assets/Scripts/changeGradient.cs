using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeGradient : MonoBehaviour
{

	public ParticlesArea particlesArea;
	bool script1 = true;

 /*
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;
    public Color color6;

    GradientColorKey[] gck;
    GradientAlphaKey[] gak;
    Gradient g;



	// Use this for initialization*/
	void Start()
	{
		/*g = new Gradient();
		gck = new GradientColorKey[6];
		gak = new GradientAlphaKey[3];

		print(gck.Length); 
		print(gak.Length); */
	}
    
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Goal")
        {
			particlesArea.gradient1 = false;
			if (script1 == true){
//                particlesArea2.enabled = true;
//				particlesArea1.enabled = false;
			}
			if (script1 == false)
            {
  //              particlesArea2.enabled = false;
	//			particlesArea1.enabled = true;
            }
			/*gck[0].color = color1;
			gck[1].color = color2;
			gck[2].color = color3;
			gck[3].color = color4;
			gck[4].color = color5;
			gck[5].color = color6;

			gak[0].alpha = 255;
			gak[1].alpha = 170;
			//gak[2].alpha = 0;

			g.SetKeys(gck, gak);

			particlesArea.m_colourGradient = g;*/



            //print("Hit Goal");
        }
	}
}

