using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	//0 for knife
	//1 for katana/sword
	//2 for pistol
	[Range(0,2)]
	public int weapon=0;

	public float[] weaponCd= {0.2f,0.3f,0.1f};

	bool alive = true;

	public Transform groundedCoord;
	public Vector2 groundedBoxSize;
	public LayerMask ground;

	public float speed=5;
	float speedModifier=1;

	public float attackDistance = 1.2f;
	public float attackDistanceKatana = 2f;

	public float jumpForce=20;

	public int souls;

	Rigidbody2D rb;
	CapsuleCollider2D capsule;

	public bool grounded;

	public Transform shootPos;
	public GameObject bulletFab;

	public int bulletCount=0;


	public float cdTimer;

	public GameManager gm;

	// Use this for initialization
	void Start () {

		gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
		rb = GetComponent<Rigidbody2D> ();
		capsule = GetComponent<CapsuleCollider2D> ();

		if (weapon == 2) {
		
			bulletCount=10;
			gm.RefreshBulletCount ();
		}


		
	}
	
	// Update is called once per frame
	void Update () {
		if (alive) {

			Physics2D.queriesStartInColliders = true;
			Collider2D col = Physics2D.OverlapBox (groundedCoord.position, groundedBoxSize, 0);

			if (col != null)
				grounded = true;
			else
				grounded = false;

			Physics2D.queriesStartInColliders = false;


	

			//Maintains constant x speed
			//rb.velocity =  new Vector2( speed * speedModifier,rb.velocity.y);

			//player will jump
			if (Input.GetKey (KeyCode.W)) {
				if (grounded) {

					rb.velocity = new Vector2 (rb.velocity.x, 0);
					rb.AddForce (Vector2.up * jumpForce);
			
			
				}

			}

			if (Input.GetKeyDown (KeyCode.S)) {
		
				//temporary
				//transform.localScale*=0.5f;

				capsule.offset = new Vector2 (0, -0.2094048f);
				capsule.size = new Vector2 (1, 0.5811905f);
			}
			if (Input.GetKeyUp (KeyCode.S)) {
		
				//temporary
				//transform.localScale*=2f;
				capsule.offset = Vector2.zero;
				capsule.size = Vector2.one;
			}

			if (Input.GetKeyDown (KeyCode.K)) {
				
				if (weapon == 2 && bulletCount == 0)
					weapon = 0;


				//kill code
				if (weapon == 0 && cdTimer>weaponCd[0]) {
					RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, attackDistance);

					if (hit.collider != null) {

						person prsn = hit.collider.gameObject.GetComponent<person> ();
						souls += prsn.souls;
						prsn.Die ();

					}
					cdTimer=0;

				} else if (weapon == 2 && cdTimer>weaponCd[2] ) {
				
					GameObject bullet = Instantiate (bulletFab, shootPos.position, Quaternion.identity);


					bullet.GetComponent<bullet> ().player = this;

					bulletCount--;
					gm.RefreshBulletCount ();

					if (bulletCount < 1)
						weapon = 0;
					//bullet.GetComponent<Rigidbody2D> ().velocity = Vector2.right * 1;
					cdTimer=0;

				} else if (weapon == 1&& cdTimer>weaponCd[1]) {

					RaycastHit2D[] hits= Physics2D.RaycastAll (transform.position, Vector2.right * transform.localScale.x, attackDistanceKatana);

					foreach (var item in hits) {
						person prsn = item.collider.gameObject.GetComponent<person> ();
						souls += prsn.souls;
						prsn.Die ();
					}


					cdTimer=0;
				}


			}

			cdTimer += Time.deltaTime;
		}else

		if (Input.GetKeyDown (KeyCode.R)) {

				gm.RestartScene ();
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "PersonBad") {
		
			Die ();
		}
	}

	public void Die(){
	
		Debug.Log ("You Died Press R to Restart");
		alive = false;
	}

	void OnDrawGizmos()
	{

		Gizmos.color = Color.blue;

		Gizmos.DrawCube (groundedCoord.transform.position, groundedBoxSize);

		Gizmos.DrawLine (transform.position, transform.position + Vector3.right * attackDistanceKatana);
	}

}
