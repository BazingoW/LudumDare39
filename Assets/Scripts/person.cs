using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class person : MonoBehaviour {

	public int souls=10;

	public int lives=1;

	public float speed=-1;
	float speedModifier=1;
	Rigidbody2D rb;

	public bool activateMovByRange;
	public float radius=5;

	public bool jump=false;
	public float jumpForce=200f;

	public Animator anim;

	public GameObject player;

	Vector3 lastPos;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x - lastPos.x > 0)
			GetComponent<SpriteRenderer> ().flipX = true;
		else if (transform.position.x - lastPos.x < 0)
			GetComponent<SpriteRenderer> ().flipX = false;

		lastPos = transform.position;

		if (activateMovByRange) {
			Physics2D.queriesStartInColliders = false;
			Collider2D[] hits = Physics2D.OverlapCircleAll (transform.position, radius);
			foreach (Collider2D h in hits)
				if (h.gameObject == player) {
					rb.velocity = new Vector2 (speed * speedModifier, rb.velocity.y);
					if (jump) {
						jump = false;
						rb.AddForce (Vector2.up * jumpForce);
					}
				}
		} else {

			rb.velocity = new Vector2 (speed * speedModifier, rb.velocity.y);
		}

		if (rb.velocity.x != 0)
			anim.SetBool ("Moving", true);
		else
			anim.SetBool ("Moving", false);
		
	}
	public void Die()
	{
		
		lives--;

		if(lives<1)
		{

			//temporary
			Destroy (this.gameObject,0.1f);
			gameObject.tag="Untagged";

		}

	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, radius);


	}
}
