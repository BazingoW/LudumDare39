﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed=5;
	float speedModifier=1;

	public float jumpForce;

	Rigidbody2D Rb;


	// Use this for initialization
	void Start () {
		Rb = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {


		//player will jump
		if (Input.GetKey (KeyCode.W)) {



		}
	}
}