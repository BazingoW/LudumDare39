using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStuff : MonoBehaviour {

	public GameObject player;
	public Vector2 offset;

	public float followTrigger;

	public bool Yfollow;

	public GameManager gm;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
		transform.position = new Vector3 (transform.position.x, player.transform.position.y+offset.y,-10);
	}
	
	// Update is called once per frame
	void Update () {
		if ((transform.position.x -player.transform.position.x < offset.x && gm.levelEnded==false)||
			(transform.position.x -player.transform.position.x < offset.x && player.GetComponent<Player>().prologueMode==true)) {
		
			if(Yfollow==false)
			transform.position = new Vector3 (player.transform.position.x + offset.x, transform.position.y, -10);
			else
				transform.position = new Vector3 (player.transform.position.x + offset.x, player.transform.position.y+offset.y, -10);
				
		}
	}
}
