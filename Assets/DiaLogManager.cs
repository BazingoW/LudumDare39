using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiaLogManager : MonoBehaviour {
	public int nextScene;

	public Transform[] pos;

	public GameObject[] sticks;

	public Text speech;

	int dialogN =0;

	public GameObject robot;

	[System.Serializable]
	public struct Dialog 
	{ public int person; 
		public string talk; }


	public Dialog[] dialog;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			SceneManager.LoadScene (0);
		}

		if (Input.GetKeyDown (KeyCode.K)) {

			if(dialogN>dialog.Length-1)
				SceneManager.LoadScene (nextScene);
			
			if (dialog [dialogN].person == 0) {
				sticks [0].SetActive (true);
				sticks [1].SetActive (false);
				speech.transform.position = pos [0].position;
			
			} else {
				sticks [0].SetActive (false);
				sticks [1].SetActive (true);
				speech.transform.position = pos [1].position;
			}

			speech.text = dialog [dialogN].talk;
			if (dialogN == 1) {
				robot.SetActive (true);
			}
			dialogN++;



		}
	}
}
