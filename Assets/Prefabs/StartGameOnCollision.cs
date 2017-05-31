using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameOnCollision : MonoBehaviour {

	private float startTime;
	private float elapsedTime;

	void Awake(){
		startTime = 0;
	
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (startTime != 0)
		{
			elapsedTime = Time.time - startTime;
			Debug.Log (elapsedTime);

		}
	}

	void OnTriggerEnter(){
		startTime = Time.time;
	}
}
