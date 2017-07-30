using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedUpBlock : MonoBehaviour {

	bool activated=false;

	public float speedAmount=1;
	public AudioSource AudioS;
	// Use this for initialization
	void Start () {
		AudioS = GetComponent<AudioSource> ();
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "Player" && activated==false) {
			col.collider.GetComponent<Player> ().speedModifier += speedAmount;
			activated=true;
			AudioS.Play ();
		}
	}
}
