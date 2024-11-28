using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListExample : MonoBehaviour
{
    public List<float> myFloats = new List<float>();

    // Update is called once per frame
    void Update()
    {
        //if we press plus
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            //Add a random float between 0 and 10
            myFloats.Add(Random.Range(0f, 10f));
        }

        //if we press minus
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            //clear the list of all floats
            myFloats.Clear();
        }
    }
}
