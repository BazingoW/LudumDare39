using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject player;

	public GameObject chunkFab;

	public GameObject lastChunk;
	public float offset;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (lastChunk.transform.position.x - player.transform.position.x < offset) {

			lastChunk = (GameObject)Instantiate (chunkFab, lastChunk.transform.position + Vector3.right * 8, Quaternion.identity);

		}

	}
}
