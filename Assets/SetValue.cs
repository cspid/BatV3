using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetValue : MonoBehaviour {

	public FlipSubtractor flipSubtractor;
	public int startValue;
	int trueValue;
	string numberAsString;

	// Use this for initialization
	void Enable () {
		trueValue = startValue;
		flipSubtractor.subtractor = 0;
		// GetComponent<Text>().text;
	}
	
	// Update is called once per frame
	void Update () {
		if (trueValue > startValue) trueValue = startValue;
		if (trueValue < 0) trueValue = 0;

		if (flipSubtractor.subtractor > startValue) flipSubtractor.subtractor = startValue;
		if (flipSubtractor.subtractor < 0) flipSubtractor.subtractor = 0;

		trueValue = startValue - flipSubtractor.subtractor;
		GetComponent<Text>().text = ("" + trueValue);
		print(trueValue);


	}
}
