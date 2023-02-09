using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colours : MonoBehaviour
{
    public GameObject[] objects;
    public Color[] objColours;
    void Start()
    {
        objects[0].GetComponent<Renderer>().material.color = objColours[0];
        objects[1].GetComponent<Renderer>().material.color = objColours[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
