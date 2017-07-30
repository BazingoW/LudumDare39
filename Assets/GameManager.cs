using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public string[] deathReason;

	public GameObject canvas;

	public Player playercmp;

	//bullet ui stuff
	public  Transform bullUIPos;
	public  List <GameObject> bullUIs = new List<GameObject>();
	public  float offset=30f;
	public  GameObject bulletUI;
	public bool levelEnded=false;
	float cumulativeOffset;

	public Image soulMeter;
	public int nextScene;

	public int DeathReason;

	public GameObject deathScreen;
	public Text deathReasonTxt;

	//singleton



	void Start () {

		playercmp = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}
	
	public void DeathStuff()
	{
		deathScreen.SetActive (true);
		deathReasonTxt.text = deathReason [DeathReason];

	}


	public void LevelEnded()
	{
		levelEnded = true;
		StartCoroutine ("ChangeScene");
	}

	public  void RestartScene()
	{
		
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);

	}

	IEnumerator ChangeScene()
	{
		yield return new WaitForSeconds (1.3f);
		SceneManager.LoadScene (nextScene);
	}

	public void RefresheSoulMeter(float soulcount)
	{
		soulMeter.fillAmount= soulcount / 100f;
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
