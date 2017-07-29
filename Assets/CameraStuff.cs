using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStuff : MonoBehaviour {

	public GameObject player;
	public Vector2 offset;

	public float followTrigger;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x -player.transform.position.x < offset.x) {
		
			transform.position = new Vector3 (player.transform.position.x + offset.x, player.transform.position.y + offset.y, -10);
		}
	}
}
