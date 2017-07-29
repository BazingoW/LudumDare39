using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineMove : MonoBehaviour {

	Rigidbody2D rb;

	public Vector2 speed= Vector2.right;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		rb.velocity = speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
