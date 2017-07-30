using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEnemies : MonoBehaviour {

	public GameObject enemy;

	public float enemySpeed=-1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D coll)
	{

		if (coll.tag == "Player") {
		
			GameObject enem = (GameObject)Instantiate (enemy, transform.GetChild (0).transform.position, Quaternion.identity);

			if(enem.GetComponent<person> ()!=null)
				enem.GetComponent<person> ().speed = -1;
		}
	}


	void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;





		Gizmos.DrawWireCube (transform.position, new Vector3 (transform.localScale.x,transform.localScale.y));


		Gizmos.DrawLine (transform.position, transform.GetChild (0).transform.position);


	}
}
