using UnityEngine;
using System.Collections;

public class SoundTrigger : MonoBehaviour {
	private AudioSource audioSource;

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log (other.gameObject.name);

			//Wenn die AudioSource noch nicht gestartet wurde
			if (!audioSource.isPlaying) {
				//dann spiele den AudioClip der AudioSource ab
				audioSource.Play ();
			}

	}

	void OnTriggerExit(Collider other) {
		//Stoppe die AudioSource
		audioSource.Stop();
	}
}