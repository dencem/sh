using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public enum JoyConRKey
    {
        None = KeyCode.None,

        A = KeyCode.JoystickButton0,
        B = KeyCode.JoystickButton2,
        X = KeyCode.JoystickButton1,
        Y = KeyCode.JoystickButton3,
        Plus = KeyCode.JoystickButton9,
        Home = KeyCode.JoystickButton12,

        R = KeyCode.JoystickButton14,
        ZR = KeyCode.JoystickButton15,

        SR = KeyCode.JoystickButton5,
        SL = KeyCode.JoystickButton4,

        // Joystick Horizontal = Joystick Axis 10.
        // Joystick Vertical = Joystick Axis 9.
    }
}
