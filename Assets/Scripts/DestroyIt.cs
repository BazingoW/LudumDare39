using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIt : MonoBehaviour {

	public bool destroyByTime = true;
	public float time2Destroy;

	public bool destroyByContact=true;

	// Use this for initialization
	void Start () {
		if(destroyByTime)
		Destroy (gameObject, time2Destroy);
	}
	
	// Update is called once per frame
	void DestroyNow () {
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (destroyByContact) {

			Destroy (gameObject);
		}
	}
}
