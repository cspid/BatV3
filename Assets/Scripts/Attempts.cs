using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attempts : MonoBehaviour {

    private int realTries;
    public int numberOfTries = 0;
    public Text numberOfFlipsText;

    public int[] attemptsList;

    void Start()
    {
        realTries = numberOfTries;
    }

    public void Add()
    {
        if(numberOfTries < realTries)
        numberOfTries += 1;
    }

    public void Subtract()
    {
        if(numberOfTries > 0)
        numberOfTries -= 1;
    }

    public void SetNumberOfTries(int number)
    {
        numberOfTries = attemptsList[number];
        realTries = attemptsList[number]; 
    }

    void Update()
    {
        numberOfFlipsText.text = "" + numberOfTries;
    }
}
