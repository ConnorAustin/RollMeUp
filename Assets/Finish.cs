﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Camera.main.GetComponent<GameManager>().SetState(GameState.Timeout);
        Camera.main.GetComponent<GameManager>().SetState(GameState.Won);
    }
}