﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    public void exit()
    {
        Application.Quit();
    }
}