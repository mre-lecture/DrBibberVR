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


	void Awake(){
		startTime = 0;

		Text[] guiTexts = FindObjectsOfType<Text> ();

		for (int i = 0; i < guiTexts.Length; i++) {
			if ("currently_running_time".Equals (guiTexts [i].name)) {
				currentTime = guiTexts [i];
			}
		}
	}

	// Use this for initialization
	void Start () {
		startCube = GameObject.Find ("CubeStartGame");

		Canvas canvas = FindObjectOfType<Canvas> ();
		if("CanvasStartGame".Equals(canvas.name)){
			startCanvas = canvas;
		}
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



	}

	void OnTriggerEnter(){
		startTime = Time.time;
		// set isPlaying=false, if all objects are grabbed and dropped to organ scale
		isPlaying = true;
	}

	void StoppingTime(bool stopTime){
		isPlaying = !stopTime;
		startCanvas.enabled = true;

		BoxCollider[] collider = startCube.GetComponents<BoxCollider> ();
		foreach (BoxCollider boxCollider in collider) {
			boxCollider.enabled = true;
		}

	}
}
