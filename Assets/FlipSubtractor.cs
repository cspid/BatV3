using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSubtractor : MonoBehaviour
{
	public int subtractor = 3;



	public void Subtract()
	{
		subtractor--;
	}

	public void Add()
	{
		subtractor++;
	}

}