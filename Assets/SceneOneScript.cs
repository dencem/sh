using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Debug.Log("What is my name : " + PlayerPrefs.GetString("Name"));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
