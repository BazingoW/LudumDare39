using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
	public Player player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "PersonBad" ||col.collider.tag == "Person") {



			person prsn = col.gameObject.GetComponent<person> ();
			player.souls += prsn.souls;
			prsn.Die ();
		}
	}
}
