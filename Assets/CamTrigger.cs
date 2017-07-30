using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col)
	{

		if (col.tag == "Player") {
			Camera.main.transform.GetComponent<CameraStuff> ().Yfollow = true;

		}

	}


	void OnTriggerExit2D(Collider2D col)
	{

		if (col.tag == "Player") {
			Camera.main.transform.GetComponent<CameraStuff> ().Yfollow = false;

		}

	}

	void OnDrawGizmos()
	{

		Gizmos.color = Color.yellow;

		Gizmos.DrawWireCube (transform.position, new Vector3 (transform.localScale.x,transform.localScale.y));
	}
}
