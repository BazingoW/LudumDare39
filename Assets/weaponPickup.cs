using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickup : MonoBehaviour {

	public	int weaponId=1;
	public int bullets=8;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.tag == "Player") {
			col.GetComponent<Player> ().weapon=weaponId;
			if (weaponId == 2) {
				col.GetComponent<Player> ().bulletCount = bullets;
				col.GetComponent<Player> ().gm.RefreshBulletCount ();
			
			}
			Destroy (gameObject, 0.3f);

		}

	}
}
