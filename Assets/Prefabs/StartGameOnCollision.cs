using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartGameOnCollision : MonoBehaviour {

	private float startTime;
	private float elapsedTime;
	Text currentTime;

	void Awake(){
		currentTime = GetComponent<Text>();
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
			float minutes = Mathf.Floor (elapsedTime / 60);
			float seconds = elapsedTime % 60;
			currentTime.text = minutes + ":" + seconds;
		}
	}

	void OnTriggerEnter(){
		startTime = Time.time;
	}
}
