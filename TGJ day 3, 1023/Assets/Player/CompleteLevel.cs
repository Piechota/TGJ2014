﻿using UnityEngine;
using System.Collections;

public class CompleteLevel : MonoBehaviour {

    public int nextIndex = 0;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Application.LoadLevel(nextIndex);            
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
