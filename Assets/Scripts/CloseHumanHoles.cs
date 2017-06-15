using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseHumanHoles : MonoBehaviour {

	bool isObjectInside;
	Transform[] children;
	bool hasCollision = false;

	void Start(){
		isObjectInside = false;
		children = GetComponentsInChildren<Transform>(true);
		foreach (Transform child in children) 
		{
			if (child != transform) {
				print (child);
				child.gameObject.SetActive (false);
			}
		}
	}
		
	void Update(){
		print ("is object inside: " + isObjectInside);
		if(isObjectInside != true){
			SetTapesOnHoles ();
		}
		isObjectInside = false;
	}

	void OnCollisionEnter(Collision coll){
		
		Debug.Log (gameObject.name + " has collided with: " + coll.gameObject.name);

		if (coll.gameObject.transform.tag == "StopTime" && this.hasCollision == false) {
			hasCollision = true;
			isObjectInside = true;
		} else {
			return;
		}
	}

	void LateUpdate(){
		this.hasCollision = false;
	}

	void SetTapesOnHoles(){
			foreach (Transform child in children) 
			{
				//print ("Child of " + child);
				if (child != transform) {
					child.gameObject.SetActive (true);
				}
			}
	}
}
