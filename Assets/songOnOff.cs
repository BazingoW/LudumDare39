using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class songOnOff : MonoBehaviour {

	public static songOnOff instance;

	public Text text;

	bool soundOn=true; 

	public AudioSource audioS;

	// Use this for initialization
	void Start () {
		instance = this;
		audioS = GetComponent<AudioSource> ();
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Started");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*void OnLevelWasLoaded()
	{Debug.Log ("Loaded");
		if (soundOn==false) {

			Camera.main.transform.GetComponent<AudioListener> ().enabled = false;
		}
	}*/


	public void SoundToggle()
	{
		soundOn = !soundOn;
		if(text!=null)
		if(soundOn)
			text.text="Music: ON";
		else
			text.text="Music: OFF";

		audioS.enabled = soundOn;


	}


}
