using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

	public bool triggerButtonDown = false;

	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	private SteamVR_Controller.Device controller{ get { return SteamVR_Controller.Input((int)trackedObj.index);}}
	private SteamVR_TrackedObject trackedObj;

	private GameObject pickup;

	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}


	void Update () {
		if (controller == null) {
			Debug.Log ("Controller is not initialized.");
			return;
		}
		if (controller.GetPressDown (gripButton) && pickup != null) {
			pickup.transform.parent = this.transform;
		}
		if (controller.GetPressUp (gripButton) && pickup != null) {
			pickup.transform.parent = null;
		}

	}
	private void OnTriggerEnter(Collider collider){
		Debug.Log (gameObject.name + "Trigger entered.");
		pickup = collider.gameObject;
	}

	private void OnTriggerExit(Collider collider){
		pickup = null;
	}
}
