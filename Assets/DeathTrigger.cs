using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.tag == "Player") {
			col.GetComponent<Player> ().Die (1);
		
		}

	}

	void OnDrawGizmos()
	{

		Gizmos.color = Color.red;

		Gizmos.DrawWireCube (transform.position, new Vector3 (transform.localScale.x,transform.localScale.y));
	}
}
