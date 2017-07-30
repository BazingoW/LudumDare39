using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prologuescript : MonoBehaviour {

	public AudioSource audios;

	public AudioClip[] clips;

	// Use this for initialization
	void Start () {
		audios = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void PlaySound(int i)
	{
		audios.clip = clips [i];
		audios.Play ();
	}
}
