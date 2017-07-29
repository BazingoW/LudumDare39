using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject canvas;

	static Player playercmp;

	//bullet ui stuff
	public  Transform bullUIPos;
	public  List <GameObject> bullUIs = new List<GameObject>();
	public  float offset=30f;
	public  GameObject bulletUI;

	float cumulativeOffset;

	//singleton



	void Start () {

		playercmp = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public  void RestartScene()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);

	}

	public  void RefreshBulletCount()


	{
		foreach (GameObject item in bullUIs) {
			Destroy (item);
		}
		bullUIs.Clear ();

		cumulativeOffset = 0;

		for (int i = 0; i < playercmp.bulletCount; i++) {
			GameObject bUI=(GameObject)Instantiate (bulletUI,bullUIPos.position+Vector3.right*cumulativeOffset,Quaternion.identity,canvas.transform);
			cumulativeOffset += offset;

			bullUIs.Add (bUI);

		}
	}

	public void Test()
	{
	}
}
