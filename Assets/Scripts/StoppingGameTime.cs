﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StoppingGameTime : MonoBehaviour {

	private static int numberOfGrabObjects;
	private int countNumberOfGrabObjects;
	private string specificTag;
	private GameObject instrumentTrolley;
	private GameObject[] gameObjectsGrab;
	private List<string> collectedGameObjectsGrab;
	private int index;

	private Dictionary<string, Vector3> gameObjectsPosition;
	private Dictionary<string, Quaternion> gameObjectsOrientation;

	void Awake(){

		specificTag = "StopTime";
		instrumentTrolley = GameObject.Find ("instrument_trolley");
		gameObjectsGrab = GameObject.FindGameObjectsWithTag (specificTag);
		numberOfGrabObjects = gameObjectsGrab.Length - 1;

		collectedGameObjectsGrab = new List<string>();
		index = 0;

		gameObjectsPosition = new Dictionary<string, Vector3> ();
		gameObjectsOrientation = new Dictionary<string,Quaternion> ();

		for (int i = 0; i < gameObjectsGrab.Length; i++) {
			gameObjectsPosition.Add (gameObjectsGrab [i].name, gameObjectsGrab [i].transform.position);
			gameObjectsOrientation.Add (gameObjectsGrab [i].name, gameObjectsGrab [i].transform.rotation);
		}
			
		SetGrabObjectsActive (false);
	}

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		if (numberOfGrabObjects == countNumberOfGrabObjects) {
			instrumentTrolley.BroadcastMessage ("StoppingTime", true);
			countNumberOfGrabObjects = 0;
            collectedGameObjectsGrab.Clear();

        }
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag (specificTag)) {


				if (!(collectedGameObjectsGrab.Contains(other.gameObject.name))) {

				collectedGameObjectsGrab.Add(other.gameObject.name);

					countNumberOfGrabObjects += 1;
				}

		}
	}

	void SetGrabObjectsActive(bool active){
		
		for (int i = 0; i < gameObjectsGrab.Length; i++) {

			if ("organ_scale".Equals (gameObjectsGrab [i].name)) {

			} else {
				
				gameObjectsGrab [i].SetActive (active);

				if (active) {
					gameObjectsGrab [i].transform.position = gameObjectsPosition [gameObjectsGrab [i].name];
					gameObjectsGrab [i].transform.rotation = gameObjectsOrientation [gameObjectsGrab [i].name];
				}
			}
		}
	}
}
