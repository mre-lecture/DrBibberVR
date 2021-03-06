using UnityEngine;
using System.Collections;

public class SoundTriggerGameEnd : MonoBehaviour {
	public AudioSource audioSourceWin;
	public AudioSource audioSourceLost;

	void Start(){

	}


	void PlaySoundOnVictory(){
		//Wenn die AudioSource noch nicht gestartet wurde
		if (!audioSourceWin.isPlaying) {
			//dann spiele den AudioClip der AudioSource ab
			audioSourceWin.Play ();
		}
	}

	void PlaySoundOnGameLost(){
		//Wenn die AudioSource noch nicht gestartet wurde
		if (!audioSourceLost.isPlaying) {
			//dann spiele den AudioClip der AudioSource ab
			audioSourceLost.Play ();
		}
	}
}