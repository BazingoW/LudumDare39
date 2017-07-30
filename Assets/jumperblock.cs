using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumperblock : MonoBehaviour {

	public	Vector2 ForceApplied=Vector2.up*10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "Player" ||
		   col.collider.tag == "Person" ||
		   col.collider.tag == "PersonBad") {
			col.collider.GetComponent<Rigidbody2D> ().velocity = new Vector2 (col.collider.GetComponent<Rigidbody2D> ().velocity.x, 0);
			col.collider.GetComponent<Rigidbody2D> ().AddForce (ForceApplied);
		}
	}
}
