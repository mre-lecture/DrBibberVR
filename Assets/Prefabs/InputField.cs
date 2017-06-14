using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputField : MonoBehaviour
{
	public InputField ()
	{
	}

	void OnTriggerEnter(){

		SteamVR.instance.overlay.ShowKeyboard (0,0,"A",256,"",true,1);
	}

	void Awake(){
	}
	void Start(){
	}
	void Update(){
	}

}

