using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StoppingGameTime : MonoBehaviour {

	private static int numberOfGrabObjects;
	private int countNumberOfGrabObjects;
	private string specificTag;
	private GameObject instrumentTrolley;

	// Use this for initialization
	void Start () {
		specificTag = "StopTime";
		instrumentTrolley = GameObject.Find ("instrument_trolley");
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag (specificTag);
		numberOfGrabObjects = GameObject.FindGameObjectsWithTag (specificTag).Length - 1;

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
}
