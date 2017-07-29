using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class person : MonoBehaviour {

	public int souls=10;

	public int lives=1;

	public float speed=-1;
	float speedModifier=1;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		rb.velocity =  new Vector2( speed * speedModifier,rb.velocity.y);
		
	}
	public void Die()
	{
		
		lives--;

		if(lives<1)
		{

			//temporary
			Destroy (this.gameObject);

		}

	}
}
