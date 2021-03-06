﻿using UnityEngine;
using System.Collections;

public class SoundTriggerGround : MonoBehaviour {
	private AudioSource audioSource;
	void Start(){
		audioSource = GetComponent<AudioSource>();
	}
	void OnTriggerEnter(Collider other) {
		if (!(other.gameObject.name == "HeadCollider" ||other.gameObject.name == "Hand1" || other.gameObject.name == "Hand2")) {
			//Wenn die AudioSource noch nicht gestartet wurde
			if (!audioSource.isPlaying) {
				//dann spiele den AudioClip der AudioSource ab
				audioSource.Play ();
			}
		}
	}
	void OnTriggerExit(Collider other) {
		//Stoppe die AudioSource
		audioSource.Stop();
	}
}