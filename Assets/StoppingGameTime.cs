using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StoppingGameTime : MonoBehaviour {

	private static int numberOfGrabObjects;
	private int countNumberOfGrabObjects;
	private string specificTag;
	private GameObject instrumentTrolley;
	private GameObject[] gameObjectsGrab;

	void Awake(){
		specificTag = "StopTime";
		instrumentTrolley = GameObject.Find ("instrument_trolley");
		gameObjectsGrab = GameObject.FindGameObjectsWithTag (specificTag);
		numberOfGrabObjects = gameObjectsGrab.Length - 1;
	
	}

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		if (numberOfGrabObjects == countNumberOfGrabObjects) {
			instrumentTrolley.BroadcastMessage ("StoppingTime", true);
			countNumberOfGrabObjects = 0;
		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag (specificTag)) {

			countNumberOfGrabObjects += 1;
			Debug.Log (countNumberOfGrabObjects);
//			Destroy(other.GetComponent("Throwable"), 10);
//			Destroy(other.GetComponent("Interactable"), 10);

		}
	}

	void SetGrabObjectsActive(bool active){
		for (int i = 0; i < gameObjectsGrab.Length; i++) {
			if ("organ_scale".Equals (gameObjectsGrab [i].name)) {

			} else {
				gameObjectsGrab [i].SetActive (active);
			}
		}
	}
}
