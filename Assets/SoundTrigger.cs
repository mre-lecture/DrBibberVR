using UnityEngine;
using System.Collections;

public class SoundTrigger : MonoBehaviour {
	private AudioSource audioSource;

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other) {

			if (!audioSource.isPlaying) {
				audioSource.Play ();
			}

	}

	void OnTriggerExit(Collider other) {
		audioSource.Stop();
	}
}