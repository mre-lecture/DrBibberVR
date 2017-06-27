using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameOnCollision : MonoBehaviour {

	private float startTime;
	private float elapsedTime;

	private float minutes;
	private float seconds;
	private string textTime;
	private Text currentTime;

	private bool isPlaying = false;

	private GameObject startCube;
	private Canvas startCanvas;

	private GameObject trashCan;
	private GameObject deadMan;
	private GameObject deadManWithHoles;
	private GameObject deadManWithoutHoles;
	private GameObject insertCube;

	Animation humanAnimation;
	GameObject childDeadman;

	void Awake(){
		startTime = 0;

		Text[] guiTexts = FindObjectsOfType<Text> ();

		for (int i = 0; i < guiTexts.Length; i++) {
			if ("currently_running_time".Equals (guiTexts [i].name)) {
				currentTime = guiTexts [i];
			}
		}

		trashCan = GameObject.Find ("trash_can");

		deadMan = GameObject.Find("dead_man");
		deadManWithHoles = GameObject.Find ("Patient");


	}

	// Use this for initialization
	void Start () {
		
		startCube = GameObject.Find ("CubeStartGame");

		Canvas [] canvas = FindObjectsOfType<Canvas> ();

		for (int i = 0; i < canvas.Length; i++) {
		
			if("CanvasStartGame".Equals(canvas[i].name)){
				startCanvas = canvas[i];
			}
		}

		deadManWithHoles.SetActive (false);

        insertCube = GameObject.Find("insertCube");
		childDeadman = GameObject.FindWithTag("ManWithoutHoleTag");
		humanAnimation = deadMan.GetComponent<Animation> ();
		Debug.Log (humanAnimation);
		humanAnimation.Stop ();

    }

	
	// Update is called once per frame
	void Update () {

		if (isPlaying) {
			startCanvas.enabled = false;

			BoxCollider[] collider = startCube.GetComponents<BoxCollider> ();
			foreach (BoxCollider boxCollider in collider) {
				boxCollider.enabled = false;
			}
		}

		if (startTime != 0 && isPlaying) {
			elapsedTime = Time.time - startTime;
			minutes = Mathf.Floor (elapsedTime / 60);
			seconds = elapsedTime % 60;

			textTime = string.Format ("{0:00}:{1:00}", minutes, seconds);
			currentTime.text = textTime.ToString ();
		} 

			
			humanAnimation.Play ();
	}

	void OnTriggerEnter(){
		startTime = Time.time;
		// set isPlaying=false, if all objects are grabbed and dropped to organ scale
		isPlaying = true;

		deadMan.SetActive (false);
		deadManWithHoles.SetActive (true);
		trashCan.BroadcastMessage("SetGrabObjectsActive", true);

        insertCube.BroadcastMessage("SetInsertCubeEnabled", false);

	}

	void StoppingTime(bool won){
        Debug.Log(won);
		isPlaying = false;
		startCanvas.enabled = true;

		BoxCollider[] collider = startCube.GetComponents<BoxCollider> ();
		foreach (BoxCollider boxCollider in collider) {
			boxCollider.enabled = true;
		}
		//childDeadman.gameObject.GetComponent<SkinnedMeshRenderer> ().enabled = true;
		deadMan.SetActive (true);
		deadManWithHoles.SetActive (false);

		humanAnimation.Play ();

		trashCan.BroadcastMessage("SetGrabObjectsActive", false);

		if (won) {
			trashCan.BroadcastMessage ("PlaySoundOnVictory");
		}else{
			trashCan.BroadcastMessage ("PlaySoundOnGameLost");
		}

		insertCube.BroadcastMessage("SetInsertCubeEnabled", won);
	}		
 
}
