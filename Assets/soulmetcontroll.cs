using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class soulmetcontroll : MonoBehaviour {


	public Image soulMet;
	// Use this for initialization
	void Start () {
		StartCoroutine ("NextScenes");
	}
	
	// Update is called once per frame
	void Update () {
		soulMet.fillAmount -= 0.08f * Time.deltaTime;
	}
	IEnumerator NextScenes()
	{
		yield return new WaitForSeconds (6);
		SceneManager.LoadScene (1);
	}
}
