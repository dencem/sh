using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

	// Use this for initialization
	void Start () {

        PlayerPrefs.SetString("Name", "Level");
        Debug.Log("DataSaved");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
